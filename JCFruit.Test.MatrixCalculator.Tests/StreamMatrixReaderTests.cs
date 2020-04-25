using JCFruit.Test.MatrixCalculator.Models;
using JCFruit.Test.MatrixCalculator.Services;
using JCFruit.Test.MatrixCalculator.Tests.Helpers;
using JCFruit.Test.MatrixCalculator.Tests.Mocks;
using Moq;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace JCFruit.Test.MatrixCalculator.Tests
{
    public class StreamMatrixReaderTests
    {
        [Fact]
        public void GetMatrices_OneMatrixInInput_OneMatrixInOutput()
        {
            var factory = new NoOpOperationFactory();
            var matrixReader = new StreamMatrixReader(factory);
            var inputString = $"noop{Environment.NewLine}{Environment.NewLine}1{Environment.NewLine}";
            var stringReader = new StringReader(inputString);
            var matrices = matrixReader.GetMatrices(stringReader);
            Assert.Single(matrices);
        }

        [Fact]
        public void GetMatrices_TwoMatrcesInInput_TwoMatrcesInOutput()
        {
            var factory = new NoOpOperationFactory();
            var matrixReader = new StreamMatrixReader(factory);
            var inputString = $"noop{Environment.NewLine}{Environment.NewLine}1{Environment.NewLine}{Environment.NewLine}1{Environment.NewLine}";
            var stringReader = new StringReader(inputString);
            var matrices = matrixReader.GetMatrices(stringReader);
            Assert.Equal(2, matrices.Count());
        }

        [Fact]
        public void GetMatrices_InconsistentAmountOfColumnsInInput_ThrowsInvalidOperationException()
        {
            var factory = new NoOpOperationFactory();
            var matrixReader = new StreamMatrixReader(factory);
            var inputString = $"noop{Environment.NewLine}{Environment.NewLine}1{Environment.NewLine}1 2{Environment.NewLine}";
            var stringReader = new StringReader(inputString);

            Assert.Throws<InvalidOperationException>(() =>
            {
                matrixReader.GetMatrices(stringReader).ToList();
            });
        }

        [Fact]
        public void GetMatrices_OneByOneMatrixInInput_ProperOutput()
        {
            var factory = new NoOpOperationFactory();
            var matrixReader = new StreamMatrixReader(factory);
            var inputString = $"noop{Environment.NewLine}{Environment.NewLine}1{Environment.NewLine}";
            var stringReader = new StringReader(inputString);
            var matrices = matrixReader.GetMatrices(stringReader);
            var expectedMatrices = new Matrix[] { new Matrix(new int[1, 1] { { 1 } }) };

            Assert.Equal(expectedMatrices, matrices, new MatrixComparer());
        }

        [Fact]
        public void GetMatrices_TwoByTwoMatrixInInput_ProperOutput()
        {
            var factory = new NoOpOperationFactory();
            var matrixReader = new StreamMatrixReader(factory);
            var inputString = $"noop{Environment.NewLine}{Environment.NewLine}1 2{Environment.NewLine}3 4{Environment.NewLine}";
            var stringReader = new StringReader(inputString);
            var matrices = matrixReader.GetMatrices(stringReader);
            var expectedMatrices = new Matrix[] { new Matrix(new int[2, 2] { { 1, 2 }, { 3, 4 } }) };

            Assert.Equal(expectedMatrices, matrices, new MatrixComparer());
        }

        [Theory]
        [InlineData("testop")]
        [InlineData("testop1")]
        [InlineData("testop2")]
        public void GetMatrices_OperationInInput_IMatrixOperationFactoryCreateCalledWithParameter(string opName)
        {
            var mock = Mock.Get(Mock.Of<IMatrixOperationFactory>());
            mock.Setup(x => x.Create(It.IsAny<string>())).Returns(new NoOpOperation()).Verifiable();
            var matrixReader = new StreamMatrixReader(mock.Object);
            var inputString = $"{opName}{Environment.NewLine}{Environment.NewLine}1{Environment.NewLine}";
            var stringReader = new StringReader(inputString);
            var matrices = matrixReader.GetMatrices(stringReader);
            mock.Verify(x => x.Create(It.Is<string>(x => x == opName)), Times.Exactly(1));
        }
    }
}
