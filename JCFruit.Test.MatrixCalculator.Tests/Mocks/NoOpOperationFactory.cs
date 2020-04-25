using JCFruit.Test.MatrixCalculator.Services;

namespace JCFruit.Test.MatrixCalculator.Tests.Mocks
{
    public class NoOpOperationFactory : IMatrixOperationFactory
    {
        public IMatrixOperation Create(string operationName)
        {
            return new NoOpOperation();
        }
    }
}
