using JCFruit.Test.MatrixCalculator.Models;
using JCFruit.Test.MatrixCalculator.Services;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JCFruit.Test.MatrixCalculator
{
    class Program
    {
        private static readonly ILogger Logger = new ConsoleLogger(LogLevel.Information);

        public static async Task Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    throw new ArgumentException($"Expected 1 startup argument. Got {args.Length}");
                }

                var fileName = args[0];

                Logger.LogInformation($"Processing directory {fileName}");

                await ProcessDirectory(fileName);
            }
            catch (Exception ex)
            {
                Logger.LogError("Exception while processing data", ex);
                throw;
            }
        }

        private static async Task ProcessDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new ArgumentException($"Directory {directory} doesn't exist", directory);
            }

            var files = Directory
                .GetFiles(directory)
                .Select(x => Path.Combine(directory, x))
                .ToList(); // Полные пути исходных файлов

            var operationFactory = new MatrixOperationFactory(Logger);
            var streamReader = new StreamMatrixReader(operationFactory);
            var streamWriter = new StreamMatrixWriter();
            var progressReporter = new ProgressReporter(files.Count, Logger);

            await files.ParallelForEachAsync(async file =>
            {
                using var input = new StreamReader(file);

                var resultFile = Path.Combine(directory, Path.GetFileNameWithoutExtension(file) + "_result.txt"); // Полный путь до файла с результатом
                await using var output = new StreamWriter(resultFile);

                var matrices = streamReader.GetMatrices(input);
                await streamWriter.WriteMatricesAsync(output, matrices);

                progressReporter.Report(file);
            });
        }
    }
}
