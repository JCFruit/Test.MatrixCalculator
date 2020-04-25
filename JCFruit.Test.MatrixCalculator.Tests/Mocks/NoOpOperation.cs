using JCFruit.Test.MatrixCalculator.Models;
using JCFruit.Test.MatrixCalculator.Services;
using System.Collections.Generic;

namespace JCFruit.Test.MatrixCalculator.Tests.Mocks
{
    public class NoOpOperation : IMatrixOperation
    {
        public IEnumerable<Matrix> Apply(IEnumerable<Matrix> input)
        {
            return input;
        }
    }
}
