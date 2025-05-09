using WordFinderChallenge.Factory;

namespace WordFinderChallenge.Test
{
    /// <summary>
    /// Run all the test with the async Alphabetic Soup
    /// THIS VERSION SEEMS TO BE MORE PERFORMANT
    /// I left the 2 implementations for comparison.
    /// </summary>
    [TestClass]
    public class WordFinderTestAsync : WordFinderTestBase
    {
        protected override AlphabeticSoupFactoryProvider.EnumAlphabeticSoupFactoryType Type => AlphabeticSoupFactoryProvider.EnumAlphabeticSoupFactoryType.AlphabeticSoupAsync;
    }
}
