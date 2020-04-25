using JCFruit.Test.MatrixCalculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace JCFruit.Test.MatrixCalculator.Services
{
    public class AddOperation : IMatrixOperation
    {
        public IEnumerable<Matrix> Apply(IEnumerable<Matrix> input)
        {
            int[,] result = null;
            foreach (var matrix in input)
            {
                if (result == null)
                {
                    result = matrix.ToArray();
                    continue;
                }

                matrix.ForEach((row, column) => result[row, column] = result[row, column] + matrix.GetCell(row, column));
            }

            if (result == null)
            {
                return Enumerable.Empty<Matrix>();
            }

            return new Matrix[1]
            {
                new Matrix(result)
            };
        }
    }
}
