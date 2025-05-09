using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFinderChallenge.Chains.MatrixValidator.Rules
{
    /// <summary>
    /// Validation rule to check that the array is not null or empty
    /// </summary>
    public class NotNullOrEmptyValidator : StringArrayValidatorBase
    {
        public override void Validate(IEnumerable<string> matrix)
        {
            if (matrix == null || matrix.ToArray().Length == 0)
                throw new ArgumentNullException("The argument cannot be null or empty");

            base.Validate(matrix);
        }
    }
}
