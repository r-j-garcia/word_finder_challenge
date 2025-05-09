using System.Collections.Generic;

namespace WordFinderChallenge.Factory.Models.Implementations
{
    /// <summary>
    /// The most simple implementation of a alphabetic soup with rows
    /// We count the ocurrences of every word and if there are more than the max then return the words with more ocurrences
    /// If there is with the same quantity of ocurrences, we order alphabetically
    /// </summary>
    public class BasicAlphabeticSoup : AlphabeticSoupWithRowsBase
    {
        /// <summary>
        /// Constructor
        /// We use the base constructor
        /// </summary>
        /// <param name="matrixRows"></param>
        public BasicAlphabeticSoup(string[] matrixRows) : base(matrixRows)
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

            //A dictionary with the ocurrences of the words
            var wordCounts = new Dictionary<string, int>(); 

            foreach (var word in distinctWords)
            {
                int count = 0;

                foreach (var row in rows)
                {
                    count += CountOccurrences(row, word);
                }

                if (count > 0)
                {
                    wordCounts[word] = count;
                }
            }

            return RemoveExcessiveWords(wordCounts);
        }
    }
}
