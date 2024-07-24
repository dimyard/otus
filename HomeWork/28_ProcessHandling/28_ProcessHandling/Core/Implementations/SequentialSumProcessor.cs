using _28_ProcessHandling.Core.Interfaces;

namespace _28_ProcessHandling.Core.Implementations;

public class SequentialSumProcessor : ISumProcessing
{
    public long ProcessSum(int[] numbers)
    {
        long sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }
        return sum;
    }

    public string Title => "📚 Sequential";
}