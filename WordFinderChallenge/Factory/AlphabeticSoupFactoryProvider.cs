using System;

namespace WordFinderChallenge.Factory
{
    /// <summary>
    /// This is a provider for Alphabetic Soups Factory
    /// Its recommended to configure this provider from settings
    /// We only use one Alphabetic Soup Type by implementation
    /// </summary>
    public static class AlphabeticSoupFactoryProvider
    {
        /// <summary>
        /// There is two factorys
        /// One is syncronous and one is async
        /// </summary>
        public enum EnumAlphabeticSoupFactoryType
        {
            AlphabeticSoup,
            AlphabeticSoupAsync
        }

        /// <summary>
        /// Get the alphabetic soup factory
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Alphabectic soup factory</returns>
        /// <exception cref="ArgumentException">If we can't handle the Factory Type</exception>
        public static IAlphabeticSoupFactory GetFactory(EnumAlphabeticSoupFactoryType type)
        {
            switch (type)
            {
                case EnumAlphabeticSoupFactoryType.AlphabeticSoup:
                    return new AlphabeticSoupFactory();
                case EnumAlphabeticSoupFactoryType.AlphabeticSoupAsync:
                    return new AlphabeticSoupFactoryAsync();
                default:
                    throw new ArgumentException("Invalid factory type.");
            }
        }
    }

}
