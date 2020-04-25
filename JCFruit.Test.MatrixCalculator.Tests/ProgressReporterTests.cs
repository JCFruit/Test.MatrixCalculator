using JCFruit.Test.MatrixCalculator.Models;
using JCFruit.Test.MatrixCalculator.Services;
using Moq;
using Xunit;

namespace JCFruit.Test.MatrixCalculator.Tests
{
    public class ProgressReporterTests
    {
        [Fact]
        public void Report_FileName_LoggerCalled()
        {
            var mock = Mock.Get(Mock.Of<ILogger>());
            mock.Setup(x => x.Log(It.IsAny<LogLevel>(),It.IsAny<string>())).Verifiable();

            var reporter = new ProgressReporter(1, mock.Object);
            reporter.Report("test.txt");

            mock.Verify(x => x.Log(It.IsAny<LogLevel>(), It.Is<string>(x => !string.IsNullOrEmpty(x))), Times.Exactly(1));
        }
    }
}
