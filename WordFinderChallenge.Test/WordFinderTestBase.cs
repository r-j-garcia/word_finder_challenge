using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WordFinderChallenge.Test
{
    /// <summary>
    /// Test Class for Word Finder
    /// </summary>
    public abstract class WordFinderTestBase
    {
        /// <summary>
        /// Word Finder Test Type
        /// </summary>
        protected abstract Factory.AlphabeticSoupFactoryProvider.EnumAlphabeticSoupFactoryType Type { get; }

        protected WordFinderTestBase()
        {
            //Set the word finder type to the provider
            WordFinder.Type = Type;
        }

        #region "Happy Path Tests"

        /// <summary>
        /// Test searching 5 words, one repeated 12 times
        /// One doesn't exist
        /// We return 4 words
        /// </summary>
        [TestMethod]
        public void Find_ReturnsFourWordsOrdered()
        {
            var stopwatch = Stopwatch.StartNew();

            var matrix = new[]
            {
                    "abcdabcd",
                    "abcdabcd",
                    "abcdabcd",
                    "abcdabcd",
                    "abcdabcd",
                    "abcdabcd",
                    "abcdabcd",
                    "abcdabcd"
                };

            var words = Enumerable.Repeat("ab", 12)
                                  .Concat(new[] { "cd", "da", "bc", "zz" })
                                  .ToArray();

            var wordFinder = new WordFinder(matrix);

            var result = wordFinder.Find(words).ToList();

            Assert.AreEqual(4, result.Count);

            stopwatch.Stop();
            Debug.WriteLine($"Find_ReturnsFourWordsOrdered executed in {stopwatch.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// Test searching 12 words in a matrix of 5x5
        /// One doesn't exist
        /// One have less Frequency
        /// Returns the first 10 (current setting)
        /// </summary>
        [TestMethod]
        public void Find_ReturnsTop10MostFrequentWords()
        {
            var stopwatch = Stopwatch.StartNew();

            var matrix = new[]
            {
                    "onetwothreeonex", 
                    "fourfiveoneseve", 
                    "eightsixonenine", 
                    "onetwothreefour", 
                    "fivesixonetwooo", 
                    "threesevenoneon", 
                    "nineeightfiveon", 
                    "onetwothreefour", 
                    "oursixonethreeo", 
                    "onefiveseveneig", 
                    "ninetenelevenon", 
                    "twothreefourfiv", 
                    "sixseveneightni", 
                    "tentwotwoonetwo", 
                    "xxxxxxxxxxxxxxx"
                };

            var finder = new WordFinder(matrix);

            var words = new[]
            {
                "one", "two", "three", "four", "five", "six", "seven",
                "eight", "nine", "ten", "eleven", "twelve" //Twelve does not appear
            };

            var result = finder.Find(words).ToList();

            Assert.AreEqual(10, result.Count);

            var expectedTop10 = new HashSet<string>
                {
                    "one", "two", "three", "four", "five",
                    "six", "seven", "eight", "nine", "ten"
                };

            foreach (var word in result)
            {
                Assert.IsTrue(expectedTop10.Contains(word));
            }

            Assert.IsFalse(result.Contains("eleven")); //Lower Frequency
            Assert.IsFalse(result.Contains("twelve")); //Does not appear

            stopwatch.Stop();
            Debug.WriteLine($"Find_ReturnsTop10MostFrequentWords executed in {stopwatch.ElapsedMilliseconds} ms");

        }

        /// <summary>
        /// Test remove empty an null words from wordstream
        /// </summary>
        [TestMethod]
        public void Find_IgnoresNullAndEmptyWords()
        {
            var stopwatch = Stopwatch.StartNew();

            var matrix = new[] { "abcd", "efgh", "ijkl", "mnop" };
            var words = new[] { "", null, "gh", "ef" };

            var wordFinder = new WordFinder(matrix);
            var result = wordFinder.Find(words).ToList();

            Assert.AreEqual(2, result.Count);
            CollectionAssert.Contains(result, "gh");
            CollectionAssert.Contains(result, "ef");

            stopwatch.Stop();
            Debug.WriteLine($"Find_IgnoresNullAndEmptyWords executed in {stopwatch.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// Test return empty where there is no matches
        /// </summary>
        [TestMethod]
        public void Find_ReturnsEmptyWhenNoMatches()
        {
            var stopwatch = Stopwatch.StartNew();

            var matrix = new[] { "abcd", "efgh", "ijkl", "mnop" };
            var words = new[] { "zzz", "yyy", "xxx" };

            var wordFinder = new WordFinder(matrix);
            var result = wordFinder.Find(words).ToList();

            Assert.AreEqual(0, result.Count);

            stopwatch.Stop();
            Debug.WriteLine($"Find_ReturnsEmptyWhenNoMatches executed in {stopwatch.ElapsedMilliseconds} ms");
        }

        #endregion

        #region "Wordstream Validation Error Test"

        /// <summary>
        /// Test sending null or empty wordstream and expect an exception
        /// </summary>
        [TestMethod]
        public void Find_ThrowsOnNullWordStream()
        {
            var stopwatch = Stopwatch.StartNew();

            var matrix = new[] { "abcd", "efgh", "ijkl", "mnop" };
            var wordFinder = new WordFinder(matrix);

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var result = wordFinder.Find(null);
            });

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var result = wordFinder.Find(new string[]{});
            });

            stopwatch.Stop();
            Debug.WriteLine($"Find_ThrowsOnNullWordStream executed in {stopwatch.ElapsedMilliseconds} ms");
        }

        #endregion

        #region "Matrix Validation Error Test"

        /// <summary>
        /// Test sending null matrix to constructor and expect an exception
        /// </summary>
        [TestMethod]
        public void Constructor_ThrowsOnNullMatrix()
        {
            var stopwatch = Stopwatch.StartNew();

            string[] matrix = null;

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var finder = new WordFinder(matrix);
            });

            stopwatch.Stop();
            Debug.WriteLine($"Constructor_ThrowsOnNullMatrix executed in {stopwatch.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// Test sending a non square matrix to constructor and expect an exception
        /// </summary>
        [TestMethod]
        public void Constructor_ThrowsOnNonSquareMatrix()
        {
            var stopwatch = Stopwatch.StartNew();

            var matrix = new[] { "abcd", "efgh", "ijkl" }; // 3x4

            Assert.ThrowsException<System.ArgumentException>(() =>
            {
                var finder = new WordFinder(matrix);
            });

            stopwatch.Stop();
            Debug.WriteLine($"Constructor_ThrowsOnNonSquareMatrix executed in {stopwatch.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// Test sending a matrix greater than the limit to constructor and expect an exception
        /// </summary>
        [TestMethod]
        public void Constructor_ThrowsOnMatrixWithMoreThan64ColumnsAndRows()
        {
            var stopwatch = Stopwatch.StartNew();

            var matrix = new string[65];
            for (int i = 0; i < 65; i++)
                matrix[i] = new string('A', 65); // 65 cols

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var finder = new WordFinder(matrix);
            });

            stopwatch.Stop();
            Debug.WriteLine($"Constructor_ThrowsOnMatrixWithMoreThan64ColumnsAndRows executed in {stopwatch.ElapsedMilliseconds} ms");
        }

        #endregion
    }
}