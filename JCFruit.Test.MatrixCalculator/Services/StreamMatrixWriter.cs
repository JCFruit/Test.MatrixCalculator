using JCFruit.Test.MatrixCalculator.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace JCFruit.Test.MatrixCalculator.Services
{
    public class StreamMatrixWriter
    {
        public async Task WriteMatricesAsync(TextWriter writer, IEnumerable<Matrix> input)
        {
            var isFirstMatrix = true;
            foreach (var matrix in input)
            {
                var sb = new StringBuilder();
                if (isFirstMatrix) // пустая строка перед матрицей если это не первая матрица
                {
                    isFirstMatrix = false;
                }
                else
                {
                    sb.AppendLine();
                }

                matrix.ForEach((row, column) =>
                {
                    sb.Append(matrix.GetCell(row, column));
                    if (column != matrix.ColumnCount - 1)
                        sb.Append(" ");
                },
                row =>
                {
                    sb.AppendLine();
                });

                await writer.WriteAsync(sb.ToString());
            }
        }
    }
}
