using JCFruit.Test.MatrixCalculator.Models;
using JCFruit.Test.MatrixCalculator.Services;

namespace JCFruit.Test.MatrixCalculator.Tests.Mocks
{
    public class NullLogger : ILogger
    {
        public void Log(LogLevel level, string message)
        {
        }
    }
}
