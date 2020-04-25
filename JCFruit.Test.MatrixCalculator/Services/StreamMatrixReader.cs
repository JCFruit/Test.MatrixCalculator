using JCFruit.Test.MatrixCalculator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JCFruit.Test.MatrixCalculator.Services
{
    public class StreamMatrixReader
    {
        private readonly IMatrixOperationFactory _factory;

        public StreamMatrixReader(IMatrixOperationFactory factory)
        {
            _factory = factory;
        }

        public IEnumerable<Matrix> GetMatrices(TextReader reader)
        {
            var operation = GetOperationFromStream(reader);
            var inputMatrices = GetMatricesFromStream(reader);
            return inputMatrices.ApplyOperation(operation);
        }

        private IMatrixOperation GetOperationFromStream(TextReader reader)
        {
            var operationName = reader.ReadLine();

            var operation = _factory.Create(operationName);

            reader.ReadLine(); //Пропускаем первую пустую строку

            return operation;
        }

        private IEnumerable<Matrix> GetMatricesFromStream(TextReader reader)
        {
            var rowList = new List<string>();
            var currentLine = reader.ReadLine();

            while (currentLine != null)
            {
                while (!string.IsNullOrEmpty(currentLine))
                {
                    rowList.Add(currentLine);
                    currentLine = reader.ReadLine();
                }

                var matrix = GetMatrixFromParsedData(rowList);
                yield return matrix;

                rowList = new List<string>();
                currentLine = reader.ReadLine();
            }
        }

        private Matrix GetMatrixFromParsedData(List<string> rowList)
        {
            var columnCount = rowList[0].Count(x => x == ' ') + 1;
            var matrix = new int[rowList.Count, columnCount];
            var rowNumber = 0;
            foreach (var row in rowList)
            {
                var columns = row
                    .Split(" ")
                    .Select(x => int.Parse(x))
                    .ToArray();

                if (columns.Length != columnCount)
                    throw new InvalidOperationException("Matrix has inconsistent amount of columns!");

                var columnNumer = 0;
                foreach (var column in columns)
                {
                    matrix[rowNumber, columnNumer] = column;
                    columnNumer++;
                }

                rowNumber++;
            }

            return new Matrix(matrix);
        }
    }
}
