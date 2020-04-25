using JCFruit.Test.MatrixCalculator.Models;
using System.Collections.Generic;

namespace JCFruit.Test.MatrixCalculator.Services
{
    public class TransposeOperation : IMatrixOperation
    {
        public IEnumerable<Matrix> Apply(IEnumerable<Matrix> input)
        {
            foreach(var matrix in input)
            {
                var newMatrix = new int[matrix.ColumnCount, matrix.RowCount];
                matrix.ForEach((row, column) => newMatrix[column, row] = matrix.GetCell(row, column));

                yield return new Matrix(newMatrix);
            }
        }
    }
}
