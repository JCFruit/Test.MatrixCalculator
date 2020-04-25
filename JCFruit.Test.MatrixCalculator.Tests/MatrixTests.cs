using JCFruit.Test.MatrixCalculator.Models;
using System;
using Xunit;

namespace JCFruit.Test.MatrixCalculator.Tests
{
    public class MatrixTests
    {
        [Theory]
        [InlineData(0, 0, 11)]
        [InlineData(0, 1, 12)]
        [InlineData(1, 0, 21)]
        [InlineData(1, 1, 22)]
        public void GetCell_InRange_ValueFromPosition(int row, int column, int expectedValue)
        {
            var matrix = new Matrix(new int[2, 2] { { 11, 12 }, { 21, 22 } });

            Assert.Equal(expectedValue, matrix.GetCell(row, column));
        }

        [Fact]
        public void GetCell_RowOutOfRange_ArgumentException ()
        {
            var matrix = new Matrix(new int[2, 2] { { 11, 12 }, { 21, 22 } });

            Assert.Throws<ArgumentException>(() => matrix.GetCell(2, 0));
        }

        [Fact]
        public void GetCell_ColumnOutOfRange_ArgumentException()
        {
            var matrix = new Matrix(new int[2, 2] { { 11, 12 }, { 21, 22 } });

            Assert.Throws<ArgumentException>(() => matrix.GetCell(0, 2));
        }
    }
}
