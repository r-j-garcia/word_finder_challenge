using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinderChallenge.Factory.Models
{
    /// <summary>
    /// Interface for a alphabetic soup
    /// </summary>
    public interface IAlphabeticSoup
    {
        /// <summary>
        /// Alphabetic soup lengt (N x N)
        /// </summary>
        byte lenght { get; }

        /// <summary>
        /// We find the word streams in the Alphabetic Soup
        /// </summary>
        /// <param name="wordstream">Word list to find in the Alphabetic Soup</param>
        /// <returns></returns>
        IEnumerable<string> Find(IEnumerable<string> wordstream);
    }
}
