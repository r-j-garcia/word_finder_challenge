using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WordFinderChallenge.Factory.Models.Implementations
{
    /// <summary>
    /// We run asynchronous threads to search in the different rows
    /// We count the ocurrences of every word and if there are more than the max then return the words with more ocurrences
    /// If there is with the same quantity of ocurrences, we order alphabetically
    /// </summary>
    public class BasicAlphabeticSoupAsync : AlphabeticSoupWithRowsBase
    {
        /// <summary>
        /// Maximum number of threads running in parallel
        /// </summary>
        protected virtual int MaxDegreeOfParallelism { get; set; } = 2;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="matrixRows">Alphabetic Soup Matrix</param>
        public BasicAlphabeticSoupAsync(string[] matrixRows): base(matrixRows)
        {

        }

        /// <summary>
        /// Find the words in the Alphabetic Soup
        /// </summary>
        /// <param name="wordstream">Word List</param>
        /// <returns>Returns the words found.If the words we find in the word search exceed the maximum, we return the words 
        /// with the most occurrences.</returns>
        public override IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var distinctWords = base.Find(wordstream);

            //User a Concurrent Dictionary to avoid parallel errors with the simple Dictionary
            var wordCounts = new ConcurrentDictionary<string, int>();

            //Configure the Parallel Foreach
            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = MaxDegreeOfParallelism
            };

            Parallel.ForEach(distinctWords, parallelOptions, word =>
            {
                if (string.IsNullOrEmpty(word))
                    return;

                int count = 0;

                foreach (var row in rows)
                {
                    count += CountOccurrences(row, word);
                }

                if (count > 0)
                {
                    wordCounts[word] = count;
                }
            });

            return RemoveExcessiveWords(new Dictionary<string, int>(wordCounts));
        }


    }
}
