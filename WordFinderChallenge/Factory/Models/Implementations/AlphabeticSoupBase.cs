using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using WordFinderChallenge.Chains.MatrixValidator;
using WordFinderChallenge.Settings;

namespace WordFinderChallenge.Factory.Models.Implementations
{
    /// <summary>
    /// Abstract class with the common implementation for all alphabetic soups
    /// </summary>
    public abstract class AlphabeticSoupBase : IAlphabeticSoup
    {
        /// <summary>
        /// Alphabetic Soup Lenght (N x N)
        /// </summary>
        protected byte _lenght;

        /// <summary>
        /// Getter for Lenght
        /// </summary>
        public byte lenght { get => _lenght; }

        /// <summary>
        /// We find the word streams in the Alphabetic Soup
        /// </summary>
        /// <param name="wordstream">Word list to find in the Alphabetic Soup</param>
        /// <returns></returns>
        public virtual IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            //Validate word stream
            StringArrayValidatorFactory.GetWordStreamValidator().Validate(wordstream);

            //Remove empty, repeated words and words larger than the size of the alphabetic soup
            var distinctWords = wordstream.Distinct().Where(x => !string.IsNullOrEmpty(x) && x.Length <= lenght);

            return distinctWords;
        }

        /// <summary>
        /// Remove excessive Words
        /// </summary>
        /// <param name="wordCounts">List of ocurrences of the words</param>
        /// <returns>Words to return</returns>
        protected static IEnumerable<string> RemoveExcessiveWords(Dictionary<string, int> wordCounts)
        {
            //If we have more words that the max we return the first ones
            if (wordCounts.Count < WordFinderSettings.MaxReturnWords)
            {
                return wordCounts.Select(x => x.Key);
            }
            else
            {
                return wordCounts
                    .OrderByDescending(kvp => kvp.Value)
                    .ThenBy(kvp => kvp.Key)
                    .Take(WordFinderSettings.MaxReturnWords)
                    .Select(kvp => kvp.Key);
            }
        }
    }
}
