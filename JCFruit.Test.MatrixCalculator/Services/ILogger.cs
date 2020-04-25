using JCFruit.Test.MatrixCalculator.Models;

namespace JCFruit.Test.MatrixCalculator.Services
{
    public interface ILogger
    {
        void Log(LogLevel level, string message);
    }
}
