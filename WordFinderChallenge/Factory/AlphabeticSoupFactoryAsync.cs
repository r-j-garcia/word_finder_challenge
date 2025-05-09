using System.Collections.Generic;
using System.Linq;
using WordFinderChallenge.Chains.MatrixValidator;
using WordFinderChallenge.Factory.Models;
using WordFinderChallenge.Factory.Models.Implementations;

namespace WordFinderChallenge.Factory
{
    /// <summary>
    /// Alphabetic Factory Soup Asyncronous
    /// </summary>
    public class AlphabeticSoupFactoryAsync: IAlphabeticSoupFactory
    {
        /// <summary>
        /// Create a Alphabetic Soup from a matrix
        /// </summary>
        /// <param name="matrix">Alphabetic Soup, is a matrix of strings</param>
        /// <returns>Alphabetic Soup Implementation</returns>
        public IAlphabeticSoup Create(IEnumerable<string> matrix)
        {
            var matrixRows = matrix.ToArray();

            //Validate matrix
            StringArrayValidatorFactory.GetMatrixValidator().Validate(matrixRows);

            //Create Alphabetic Soup
            return new BasicAlphabeticSoupAsync(matrixRows);
        }
    }
}
