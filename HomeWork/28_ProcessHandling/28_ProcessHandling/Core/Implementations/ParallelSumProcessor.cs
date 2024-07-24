using System.Collections.Concurrent;
using _28_ProcessHandling.Core.Interfaces;

namespace _28_ProcessHandling.Core.Implementations;

public class ParallelSumProcessor : ISumProcessing
{
    public long ProcessSum(int[] numbers)
    {
        const int numThreads = 8;
        var range = numbers.Length / numThreads;
        ConcurrentBag<long> results = new ConcurrentBag<long>();
        var threads = new List<Thread>();

        for (int i = 0; i < numThreads; i++)
        {
            int start = i * range;
            int end = (i == numThreads - 1) ? numbers.Length : start + range;

            threads.Add(new Thread(() =>
            {
                long sum = 0;
                for (int j = start; j < end; j++)
                {
                    sum += numbers[j];
                }
                results.Add(sum);
            }));
        }

        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return results.Sum();
    }
    
    public string Title => "⏸️ Parallel";
}