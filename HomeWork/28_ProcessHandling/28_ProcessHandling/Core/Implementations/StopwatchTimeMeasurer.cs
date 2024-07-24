using System.Diagnostics;
using _28_ProcessHandling.Core.Interfaces;

namespace _28_ProcessHandling.Core.Implementations;

public class StopwatchTimeMeasurer : ITimeMeasurer
{
    public long Measure(Action action)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        action();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }
    
    public static void MeasureAndPrintTime(string methodTitle, ISumProcessing processor, int[] numbers, ITimeMeasurer timeMeasurer)
    {
        long time = timeMeasurer.Measure(() => processor.ProcessSum(numbers));
        long sum = processor.ProcessSum(numbers);
        Console.WriteLine($"{methodTitle} Sum: {sum}, Time: ⏱️ {time} ms");
    }
}