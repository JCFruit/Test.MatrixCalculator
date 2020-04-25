using JCFruit.Test.MatrixCalculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace JCFruit.Test.MatrixCalculator.Services
{
    public class MultiplyOperation : IMatrixOperation
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

                result = Multiply(result, matrix);
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

        private static int[,] Multiply(int[,] leftMatrix, Matrix rightMatrix)
        {
            var newRowCount = leftMatrix.GetUpperBound(0) + 1;
            var newColumnCount = rightMatrix.ColumnCount;
            var newMatrix = new int[newRowCount, newColumnCount];

            for(var newRow = 0; newRow < newRowCount; newRow++)
            {
                for(var newColumn = 0; newColumn < newColumnCount; newColumn++)
                {
                    newMatrix[newRow, newColumn] = CalculateCell(leftMatrix, rightMatrix, newRow, newColumn);
                }
            }

            return newMatrix;
        }

        private static int CalculateCell(int[,] leftMatrix, Matrix rightMatrix, int row, int column)
        {
            var result = 0;
            for(var i = 0; i < rightMatrix.RowCount; i++)
            {
                result = result + leftMatrix[row, i] * rightMatrix.GetCell(i, column);
            }

            return result;
        }
    }
}
