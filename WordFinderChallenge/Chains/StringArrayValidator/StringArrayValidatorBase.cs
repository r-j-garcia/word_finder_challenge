using System.Collections.Generic;

namespace WordFinderChallenge.Chains.MatrixValidator
{
    /// <summary>
    /// Base class to String Array Validation Rule
    /// </summary>
    public abstract class StringArrayValidatorBase : IStringArrayValidator
    {
        private IStringArrayValidator _next;

        /// <summary>
        /// Set next rule
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public IStringArrayValidator SetNext(IStringArrayValidator next)
        {
            _next = next;
            return _next;
        }

        /// <summary>
        /// Validate the next rule
        /// </summary>
        /// <param name="matrix"></param>
        public virtual void Validate(IEnumerable<string> matrix)
        {
            _next?.Validate(matrix);
        }
    }
}
