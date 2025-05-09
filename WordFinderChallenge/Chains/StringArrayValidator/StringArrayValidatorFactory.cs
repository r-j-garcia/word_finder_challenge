using WordFinderChallenge.Chains.MatrixValidator.Rules;

namespace WordFinderChallenge.Chains.MatrixValidator
{
    /// <summary>
    /// String Array Validators Factory
    /// Get the validations chains for the diferents validations of string arrays
    /// </summary>
    public class StringArrayValidatorFactory
    {
        /// <summary>
        /// Validation chain for alphabetic soup matrix
        /// </summary>
        /// <returns></returns>
        public static StringArrayValidatorBase GetMatrixValidator()
        {
            var rules = new NotNullOrEmptyValidator();

            rules
                .SetNext(new MaxSizeValidator())
                .SetNext(new SquareMatrixValidator());

            return rules;
        }

        /// <summary>
        /// Validation chain for word streams for the alphabetic soup
        /// </summary>
        /// <returns></returns>
        public static StringArrayValidatorBase GetWordStreamValidator()
        {
            var rules = new NotNullOrEmptyValidator();

            return rules;
        }
    }
}
