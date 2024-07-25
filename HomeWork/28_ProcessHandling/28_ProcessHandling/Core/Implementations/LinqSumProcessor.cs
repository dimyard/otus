using _28_ProcessHandling.Core.Interfaces;

namespace _28_ProcessHandling.Core.Implementations;

public class LinqSumProcessor : ISumProcessing
{
    public long ProcessSum(long[] numbers)
    {
        return numbers.AsParallel().Sum(number => number);
    }

    public string Title => "✨  LINQ: AsParallel";
}