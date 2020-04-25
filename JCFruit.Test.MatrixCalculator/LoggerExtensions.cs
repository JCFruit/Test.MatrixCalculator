using JCFruit.Test.MatrixCalculator.Models;
using JCFruit.Test.MatrixCalculator.Services;
using System;

namespace JCFruit.Test.MatrixCalculator
{
    public static class LoggerExtensions
    {
        public static void LogDebug(this ILogger logger, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Debug, message);
        }

        public static void LogInformation(this ILogger logger, string message)
        {
            if(logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Information, message);
        }

        public static void LogError(this ILogger logger, string message, Exception ex = null)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if(ex != null)
            {
                message = message + Environment.NewLine + ex.ToString();
            }

            logger.Log(LogLevel.Error, message);
        }
    }
}
