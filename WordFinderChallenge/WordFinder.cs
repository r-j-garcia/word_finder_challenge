using System.Collections.Generic;
using WordFinderChallenge.Factory;
using WordFinderChallenge.Factory.Models;

namespace WordFinderChallenge
{
    /// <summary>
    /// Word Finder Class 
    /// </summary>
    public class WordFinder
    {
        /// <summary>
        /// We can use this configuration to test different implementations of WordFinder.
        // There is now a regular version and an asynchronous version implemented
        /// </summary>
        public static AlphabeticSoupFactoryProvider.EnumAlphabeticSoupFactoryType Type = AlphabeticSoupFactoryProvider.EnumAlphabeticSoupFactoryType.AlphabeticSoup;

        /// <summary>
        /// Alphabetic soup
        /// </summary>
        private readonly IAlphabeticSoup _alphabeticSoup;

        /// <summary>
        /// We get the Alphabetic Soup
        /// First we get the Factory (Normal or Async)
        /// Then we create the Alphabetic Soup
        /// </summary>
        /// <param name="matrix">Alphabetic Soup, is a matrix of strings</param>
        public WordFinder(IEnumerable<string> matrix)
        {
            this._alphabeticSoup = AlphabeticSoupFactoryProvider.GetFactory(Type).Create(matrix);
        }

        /// <summary>
        /// We find the word streams in the Alphabetic Soup
        /// We use the Alphabetic Soup configured in the constructor
        /// </summary>
        /// <param name="wordstream">Word list to find in the Alphabetic Soup</param>
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            return this._alphabeticSoup.Find(wordstream);
        }
    }
}
