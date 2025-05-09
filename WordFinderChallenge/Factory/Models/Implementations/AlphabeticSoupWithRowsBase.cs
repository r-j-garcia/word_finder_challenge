using System;

namespace WordFinderChallenge.Factory.Models.Implementations
{
    /// <summary>
    /// Abstract class with common implementation for all Alphabetic Soup that transforms the matrix into a single rows array
    /// </summary>
    public abstract class AlphabeticSoupWithRowsBase: AlphabeticSoupBase
    {
        /// <summary>
        /// All rows to search
        /// </summary>
        protected readonly string[] rows;

        /// <summary>
        /// Transform the rows and the columns of the matrix to a single rows array
        /// </summary>
        /// <param name="matrixRows">Alphabetic Soup Matrix</param>
        public AlphabeticSoupWithRowsBase(string[] matrixRows)
        {
            //Set the lenght of the matrix
            _lenght = (byte)matrixRows.Length;

            //Create an array with the exact  size (2 x rows)
            rows = new string[2 * lenght];

            //Add all the rows
            for (byte i = 0; i < lenght; i++)
            {
                rows[i] = matrixRows[i];
            }

            //Add all the columns
            for (byte col = 0; col < lenght; col++)
            {
                char[] colChars = new char[lenght];
                for (byte row = 0; row < lenght; row++)
                {
                    colChars[row] = matrixRows[row][col];
                }
                rows[lenght + col] = new string(colChars);
            }
        }

        /// <summary>
        /// Count ocurrences of a word in the row
        /// Only in one way
        /// </summary>
        /// <param name="text">Row</param>
        /// <param name="word">Word to search</param>
        /// <returns>Quantity of ocurrences of the word in the row</returns>
        protected int CountOccurrences(string text, string word)
        {
            int count = 0;
            int index = 0;

            //We search until there is no more ocurrences of the word in the row
            while ((index = text.IndexOf(word, index, StringComparison.Ordinal)) != -1)
            {
                //Add an ocurrence
                count++;

                //Move to the final of the word (avoid overlapping)
                index += word.Length;
            }

            return count;
        }
    }
}
