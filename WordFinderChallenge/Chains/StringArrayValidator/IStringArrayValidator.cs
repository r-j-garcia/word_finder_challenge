using System.Collections.Generic;

namespace WordFinderChallenge.Chains.MatrixValidator
{
    /// <summary>
    /// Interface for String Array Validation Rule
    /// </summary>
    public interface IStringArrayValidator
    {
        IStringArrayValidator SetNext(IStringArrayValidator next);
        void Validate(IEnumerable<string> matrix);
    }
}
