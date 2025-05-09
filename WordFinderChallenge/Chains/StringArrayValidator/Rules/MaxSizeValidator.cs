using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using WordFinderChallenge.Settings;

namespace WordFinderChallenge.Chains.MatrixValidator.Rules
{
    /// <summary>
    /// Validation rule to check the size of the matrix
    /// The value of MaxMatrixSize is obtained from a configuration, because we dont use IOptions right now
    /// </summary>
    public class MaxSizeValidator : StringArrayValidatorBase
    {
        /// <summary>
        /// Max size for the matrix
        /// </summary>
        private readonly int _maxMatrixSize;

        public MaxSizeValidator()
        {
            _maxMatrixSize = WordFinderSettings.MaxMatrixSize;
        }

        public override void Validate(IEnumerable<string> matrix)
        {
            if (matrix.ToArray().Length > _maxMatrixSize)
                throw new ArgumentOutOfRangeException("Matrix size exceeds 255");

            base.Validate(matrix);
        }
    }
}
