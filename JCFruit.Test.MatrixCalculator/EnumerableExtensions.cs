using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JCFruit.Test.MatrixCalculator
{
    public static class EnumerableExtensions
    {

        public static Task ParallelForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> funcBody)
            => ParallelForEachAsync(source, funcBody, Environment.ProcessorCount);

        public static Task ParallelForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> funcBody, int maxDoP)
        {
            async Task AwaitPartition(IEnumerator<T> partition)
            {
                using (partition)
                {
                    while (partition.MoveNext())
                    { 
                        await funcBody(partition.Current); 
                    }
                }
            }

            return Task.WhenAll(
                Partitioner
                    .Create(source)
                    .GetPartitions(maxDoP)
                    .Select(p => AwaitPartition(p)));
        }
    }
}
