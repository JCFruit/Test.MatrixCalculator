using System.IO;
using System.Threading;

namespace JCFruit.Test.MatrixCalculator.Services
{
    public class ProgressReporter
    {
        private readonly ILogger _logger;
        private readonly int _totalCount;
        private int _currentCount;

        public ProgressReporter(int totalCount, ILogger logger)
        {
            _logger = logger;
            _totalCount = totalCount;
        }

        public void Report(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            Interlocked.Increment(ref _currentCount);
            _logger.LogInformation($"File \'{fileName}\' processed. {_currentCount}/{_totalCount}");
        }
    }
}
