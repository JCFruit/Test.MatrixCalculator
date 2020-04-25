using JCFruit.Test.MatrixCalculator.Models;
using JCFruit.Test.MatrixCalculator.Services;
using System;
using System.Collections.Generic;

namespace JCFruit.Test.MatrixCalculator
{
    public static class MatrixExtensions
    {
        public static void ForEach(this Matrix matrix, Action<int, int> eachCell = null, Action<int> eachRow = null)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            for (var row = 0; row < matrix.RowCount; row++)
            {
                for (var column = 0; column < matrix.ColumnCount; column++)
                {
                    eachCell(row, column);
                }

                eachRow?.Invoke(row);
            }
        }

        public static IEnumerable<Matrix> ApplyOperation(this IEnumerable<Matrix> source, IMatrixOperation operation)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            return operation.Apply(source);
        }
    }
}
