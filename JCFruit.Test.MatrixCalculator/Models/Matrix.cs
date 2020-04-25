using System;

namespace JCFruit.Test.MatrixCalculator.Models
{
    public class Matrix
    {
        private readonly int[,] _matrix;

        public int RowCount { get; set; }

        public int ColumnCount { get; set; }

        public Matrix(int[,] data)
        {
            _matrix = data;
            RowCount = _matrix.GetUpperBound(0) + 1;
            ColumnCount = _matrix.GetUpperBound(1) + 1;
        }

        public int[,] ToArray()
        {
            var array = new int[RowCount, ColumnCount];
            MatrixExtensions.ForEach(this, (row, column) => array[row, column] = _matrix[row, column]);

            return array;
        }

        public int GetCell(int row, int column)
        {
            if (row >= RowCount || row < 0)
                throw new ArgumentException($"Row must be in [0, {RowCount}) range", nameof(row));

            if (column >= ColumnCount || column < 0)
                throw new ArgumentException($"Column must be in [0, {ColumnCount}) range", nameof(column));

            return _matrix[row, column];
        }
    }
}
