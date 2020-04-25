namespace JCFruit.Test.MatrixCalculator.Services
{
    public interface IMatrixOperationFactory
    {
        IMatrixOperation Create(string operationName);
    }
}
