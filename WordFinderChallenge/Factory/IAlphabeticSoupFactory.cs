using System.Collections.Generic;
using WordFinderChallenge.Factory.Models;

namespace WordFinderChallenge.Factory
{
    /// <summary>
    /// Interface to Alphabetic Soup Factory
    /// </summary>
    public interface IAlphabeticSoupFactory
    {
        /// <summary>
        /// Create an alphabetic soup implementation
        /// We can get differents implementations by the matrix
        /// For example, if the matrix is very large, we can have a specific implementation
        /// </summary>
        /// <param name="matrix">Alphabetic Soup, is a matrix of strings</param>
        /// <returns>Alphabetic Soup Implementation</returns>
        IAlphabeticSoup Create(IEnumerable<string> matrix);
    }
}
