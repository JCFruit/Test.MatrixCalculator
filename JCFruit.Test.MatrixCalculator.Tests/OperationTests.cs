using JCFruit.Test.MatrixCalculator.Models;
using JCFruit.Test.MatrixCalculator.Services;
using JCFruit.Test.MatrixCalculator.Tests.Helpers;
using System.Linq;
using Xunit;

namespace JCFruit.Test.MatrixCalculator.Tests
{
    public class OperationTests
    {
        [Fact]
        public void AddOperation_TwoMatrices_MatricesAdded()
        {
            var matrix1 = new Matrix(new int[2, 2] { { 1, 2 }, { 3, 4 } });
            var matrix2 = new Matrix(new int[2, 2] { { 1, 2 }, { 3, 4 } });
            var expectedMatrix = new Matrix(new int[2, 2] { { 2, 4 }, { 6, 8 } });

            var inputArray = new Matrix[] { matrix1, matrix2 };
            var expectedArray = new Matrix[] { expectedMatrix };

            var opratrion = new AddOperation();

            var output = opratrion.Apply(inputArray);

            Assert.Equal(expectedArray, output, new MatrixComparer());
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public void AddOperation_TwoMatricesWithDifferentOrder_OrderDoesNotMatter(int i1, int i2)
        {
            var matrix1 = new Matrix(new int[1, 1] { { i1 }});
            var matrix2 = new Matrix(new int[1, 1] { { i2 }});
            var expectedMatrix = new Matrix(new int[1, 1] { { i1 + i2 } });

            var inputArray = new Matrix[] { matrix1, matrix2 };
            var expectedArray = new Matrix[] { expectedMatrix };

            var opratrion = new AddOperation();

            var output = opratrion.Apply(inputArray);

            Assert.Equal(expectedArray, output, new MatrixComparer());
        }

        [Fact]
        public void SubtractOperation_TwoMatrices_MatricesSubtracted()
        {
            var matrix1 = new Matrix(new int[2, 2] { { 1, 2 }, { 3, 4 } });
            var matrix2 = new Matrix(new int[2, 2] { { 1, 2 }, { 3, 4 } });
            var expectedMatrix = new Matrix(new int[2, 2] { { 0, 0 }, { 0, 0 } });

            var inputArray = new Matrix[] { matrix1, matrix2 };
            var expectedArray = new Matrix[] { expectedMatrix };

            var opratrion = new SubtractOperation();

            var output = opratrion.Apply(inputArray);

            Assert.Equal(expectedArray, output, new MatrixComparer());
        }

        [Fact]
        public void TransposeOperation_TwoMatrices_ReturnedTwoMatrices()
        {
            var matrix1 = new Matrix(new int[2, 2] { { 1, 2 }, { 3, 4 } });
            var matrix2 = new Matrix(new int[2, 2] { { 5, 6 }, { 7, 8 } });

            var inputArray = new Matrix[] { matrix1, matrix2 };

            var opratrion = new TransposeOperation();

            var output = opratrion.Apply(inputArray);

            Assert.Equal(2, output.Count());
        }

        [Fact]
        public void TransposeOperation_One2x2Matrix_MatrixTransposed()
        {
            var inputMatrix = new Matrix(new int[2, 2] { { 1, 2 }, { 3, 4 } });
            var expectedMatrix = new Matrix(new int[2, 2] { { 1, 3 }, { 2, 4 } });

            var inputArray = new Matrix[] { inputMatrix };
            var expectedArray = new Matrix[] { expectedMatrix };

            var opratrion = new TransposeOperation();

            var output = opratrion.Apply(inputArray);

            Assert.Equal(expectedArray, output, new MatrixComparer());
        }

        [Fact]
        public void MultiplyOperation_TwoMatrices_OneMatrix()
        {
            var input1 = new Matrix(new int[1, 1] { { 1 } });
            var input2 = new Matrix(new int[1, 1] { { 1 } });

            var inputArray = new Matrix[] { input1, input2 };

            var operation = new MultiplyOperation();
            var output = operation.Apply(inputArray);

            Assert.Single(output);
        }

        [Fact]
        public void MultiplyOperation_TwoMatricesWithOneValue_MatricesMultiplied()
        {
            var input1 = new Matrix(new int[2, 2] { { 1, 1 }, { 1, 1 } });
            var input2 = new Matrix(new int[2, 2] { { 2, 2 }, { 2, 2 } });
            var expectedMatrix = new Matrix(new int[2, 2] { { 4, 4 }, { 4, 4 } });

            var inputArray = new Matrix[] { input1, input2 };
            var expectedArray = new Matrix[] { expectedMatrix };

            var operation = new MultiplyOperation();
            var output = operation.Apply(inputArray);

            Assert.Equal(expectedArray, output, new MatrixComparer());
        }

        [Fact]
        public void MultiplyOperation_TwoMatrices_MatricesMultiplied()
        {
            var input1 = new Matrix(new int[2, 2] { { 1, 2 }, { 3, 4 } });
            var input2 = new Matrix(new int[2, 2] { { 5, 6 }, { 7, 8 } });
            var expectedMatrix = new Matrix(new int[2, 2] { { 19, 22 }, { 43, 50 } });

            var inputArray = new Matrix[] { input1, input2 };
            var expectedArray = new Matrix[] { expectedMatrix };

            var operation = new MultiplyOperation();
            var output = operation.Apply(inputArray);

            Assert.Equal(expectedArray, output, new MatrixComparer());
        }

        [Fact]
        public void MultiplyOperation_1x2by2x1_1x1Matrix()
        {
            var input1 = new Matrix(new int[1, 2] { { 1, 2 } });
            var input2 = new Matrix(new int[2, 1] { { 1 }, { 2 } });

            var inputArray = new Matrix[] { input1, input2 };

            var operation = new MultiplyOperation();
            var output = operation.Apply(inputArray).Single();

            Assert.Equal(1, output.RowCount);
            Assert.Equal(1, output.ColumnCount);
        }

        [Fact]
        public void MultiplyOperation_2x1by1x2_2x2Matrix()
        {
            var input1 = new Matrix(new int[2, 1] { { 1 }, { 2 } });
            var input2 = new Matrix(new int[1, 2] { { 1, 2 } });

            var inputArray = new Matrix[] { input1, input2 };

            var operation = new MultiplyOperation();
            var output = operation.Apply(inputArray).Single();

            Assert.Equal(2, output.RowCount);
            Assert.Equal(2, output.ColumnCount);
        }
    }
}
