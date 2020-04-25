using JCFruit.Test.MatrixCalculator.Services;
using JCFruit.Test.MatrixCalculator.Tests.Mocks;
using System;
using Xunit;

namespace JCFruit.Test.MatrixCalculator.Tests
{
    public class MatrixOperationFactoryTests
    {
        [Fact]
        public void Create_Add_AddOperation()
        {
            var factory = new MatrixOperationFactory(new NullLogger());
            var operation = factory.Create("add");
            Assert.IsType<AddOperation>(operation);
        }

        [Fact]
        public void Create_Subtract_SubtractOperation()
        {
            var factory = new MatrixOperationFactory(new NullLogger());
            var operation = factory.Create("subtract");
            Assert.IsType<SubtractOperation>(operation);
        }

        [Fact]
        public void Create_Transpose_TransposeOperation()
        {
            var factory = new MatrixOperationFactory(new NullLogger());
            var operation = factory.Create("transpose");
            Assert.IsType<TransposeOperation>(operation);
        }

        [Fact]
        public void Create_Multiply_MultiplyOperation()
        {
            var factory = new MatrixOperationFactory(new NullLogger());
            var operation = factory.Create("multiply");
            Assert.IsType<MultiplyOperation>(operation);
        }

        [Fact]
        public void Create_InvalidInput_ThrowsInvalidOperationException()
        {
            var factory = new MatrixOperationFactory(new NullLogger());
            Assert.Throws<InvalidOperationException>(() => factory.Create("testData"));
        }
    }
}
