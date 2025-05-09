namespace WordFinderChallenge.Settings
{
    /// <summary>
    /// Settings for Word Finder
    /// We do not use IOptions to maintain the WordFinder signature.
    /// </summary>
    public class WordFinderSettings
    {
        /// <summary>
        /// Max size for the Alphabetic Soup Matrix
        /// </summary>
        public static int MaxMatrixSize { get; set; } = 64;

        /// <summary>
        /// Maximum number of words we can return
        /// </summary>
        public static int MaxReturnWords { get; set; } = 10;
    }
}
