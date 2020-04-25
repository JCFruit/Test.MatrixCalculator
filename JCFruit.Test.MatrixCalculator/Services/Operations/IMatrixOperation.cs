using JCFruit.Test.MatrixCalculator.Models;
using System.Collections.Generic;

namespace JCFruit.Test.MatrixCalculator.Services
{
    public interface IMatrixOperation
    {
        IEnumerable<Matrix> Apply(IEnumerable<Matrix> input);
    }
}
