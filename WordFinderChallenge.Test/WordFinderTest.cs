using WordFinderChallenge.Factory;

namespace WordFinderChallenge.Test
{
    /// <summary>
    /// Run all the test with the normal Alphabetic Soup
    /// </summary>
    [TestClass]
    public class WordFinderTest : WordFinderTestBase
    {
        protected override AlphabeticSoupFactoryProvider.EnumAlphabeticSoupFactoryType Type => AlphabeticSoupFactoryProvider.EnumAlphabeticSoupFactoryType.AlphabeticSoup;
    }
}
