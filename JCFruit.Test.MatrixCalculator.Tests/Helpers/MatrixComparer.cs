using JCFruit.Test.MatrixCalculator.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace JCFruit.Test.MatrixCalculator.Tests.Helpers
{
    public class MatrixComparer : IEqualityComparer<Matrix>
    {
        public bool Equals([AllowNull] Matrix left, [AllowNull] Matrix right)
        {
            if(left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            var equals = left.RowCount == right.RowCount && left.ColumnCount == right.ColumnCount;
            if (equals)
            {
                left.ForEach((row, column) => equals = equals && left.GetCell(row, column) == right.GetCell(row, column));
            }
            return equals;
        }

        public int GetHashCode([DisallowNull] Matrix obj)
        {
            return 0;
        }
    }
}
