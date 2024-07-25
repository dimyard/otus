using System.Text;
using _28_ProcessHandling.Core.Implementations;
using _28_ProcessHandling.Core.Interfaces;

namespace _28_ProcessHandling.External
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] sizes = [100_000, 1_000_000, 10_000_000]; // sugaaaar ^_^
            var random = new Random();
            Console.OutputEncoding = Encoding.UTF8; // ⭐
            
            ITimeMeasurer timeMeasurer = new StopwatchTimeMeasurer();
            var processorsList = new List<ISumProcessing>
            {
                new SequentialSumProcessor(), 
                new ParallelSumProcessor(), 
                new LinqSumProcessor(),
                new SumLinqSumProcessor()
            };
            
            Console.WriteLine("🚀 Start Processing 🚀");
            Console.WriteLine($"⚡ CPU cores count: {Environment.ProcessorCount}");
            
            foreach (var size in sizes)
            {
                long[] numbers = new long[size];
                for (int i = 0; i < size; i++)
                {
                    numbers[i] = random.Next(1, 100);
                }

                Console.WriteLine($"Current array Size: {size}");

                foreach (var sumProcessing in processorsList)
                {
                    StopwatchTimeMeasurer.MeasureAndPrintTime(sumProcessing.Title, sumProcessing, numbers, timeMeasurer);
                }

                Console.WriteLine();
            }
        }
    }
}