using _28_ProcessHandling.Core.Interfaces;

namespace _28_ProcessHandling.Core.Implementations;

public class SumLinqSumProcessor : ISumProcessing
{
    public long ProcessSum(long[] numbers)
    {
        return numbers.Sum(number => number);
    }
    
    public string Title => "🪄 LINQ: SimpleSum";
}