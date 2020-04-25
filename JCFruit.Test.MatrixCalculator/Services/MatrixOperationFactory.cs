using System;

namespace JCFruit.Test.MatrixCalculator.Services
{
    public class MatrixOperationFactory : IMatrixOperationFactory
    {
        private readonly ILogger _logger;
        
        public MatrixOperationFactory(ILogger logger)
        {
            _logger = logger;
        }

        public IMatrixOperation Create(string operationName)
        {
            _logger.LogDebug($"Requested operation: {operationName}");

            switch (operationName)
            {
                case "add":
                    return new AddOperation();
                case "subtract":
                    return new SubtractOperation();
                case "transpose":
                    return new TransposeOperation();
                case "multiply":
                    return new MultiplyOperation();
                default:
                    throw new InvalidOperationException($"Operation {operationName} is not supported");
            }
        }
    }
}
