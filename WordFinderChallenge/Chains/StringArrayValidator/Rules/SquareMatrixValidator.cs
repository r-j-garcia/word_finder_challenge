using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFinderChallenge.Chains.MatrixValidator.Rules
{
    /// <summary>
    /// Validation rule to check that the matrix is ​​square
    /// </summary>
    public class SquareMatrixValidator : StringArrayValidatorBase
    {
        public override void Validate(IEnumerable<string> matrix)
        {
            int expectedLength = matrix.ToArray().Length;
            if (matrix.Any(r => r.Length != expectedLength))
                throw new ArgumentException("Matrix must be square (NxN)");

            base.Validate(matrix);
        }
    }
}
