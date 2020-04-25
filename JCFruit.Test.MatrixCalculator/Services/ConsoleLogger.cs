using JCFruit.Test.MatrixCalculator.Models;
using System;
using System.Threading;

namespace JCFruit.Test.MatrixCalculator.Services
{
    public class ConsoleLogger : ILogger
    {
        private readonly LogLevel _minLevel;

        public ConsoleLogger(LogLevel mininumLevel)
        {
            _minLevel = mininumLevel;
        }

        public void Log(LogLevel level, string message)
        {
            if(level >= _minLevel)
            {
                var logMessage = $"[{DateTime.UtcNow:s}] [{level}:{Thread.CurrentThread.ManagedThreadId}] {message}";
                Console.WriteLine(logMessage);
            }
        }
    }
}
