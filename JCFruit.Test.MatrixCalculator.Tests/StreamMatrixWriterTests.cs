using JCFruit.Test.MatrixCalculator.Models;
using JCFruit.Test.MatrixCalculator.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace JCFruit.Test.MatrixCalculator.Tests
{
    public class StreamMatrixWriterTests
    {
        [Fact]
        public async Task Write_OneMatrix_ValidOutput()
        {
            var array = new int[1,1] { { 1 } };
            var matrixArray = new Matrix[] { new Matrix(array) };

            var stringWriter = new StringWriter();
            var matrixWriter = new StreamMatrixWriter();
            await matrixWriter.WriteMatricesAsync(stringWriter, matrixArray);

            var ourputString = stringWriter.ToString();
            var exprected = $"1{Environment.NewLine}";
            Assert.Equal(exprected, ourputString);
        }

        [Fact]
        public async Task Write_TwoMatrices_ValidOutput()
        {
            var array = new int[1, 1] { { 1 } };
            var matrixArray = new Matrix[] { new Matrix(array), new Matrix(array) };

            var stringWriter = new StringWriter();
            var matrixWriter = new StreamMatrixWriter();
            await matrixWriter.WriteMatricesAsync(stringWriter, matrixArray);

            var ourputString = stringWriter.ToString();
            var exprected = $"1{Environment.NewLine}{Environment.NewLine}1{Environment.NewLine}";
            Assert.Equal(exprected, ourputString);
        }

        [Fact]
        public async Task Write_TwoByTwoMatrix_ValidOutput()
        {
            var array = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            var matrixArray = new Matrix[] { new Matrix(array) };

            var stringWriter = new StringWriter();
            var matrixWriter = new StreamMatrixWriter();
            await matrixWriter.WriteMatricesAsync(stringWriter, matrixArray);

            var ourputString = stringWriter.ToString();
            var exprected = $"1 2{Environment.NewLine}3 4{Environment.NewLine}";
            Assert.Equal(exprected, ourputString);
        }
    }
}
