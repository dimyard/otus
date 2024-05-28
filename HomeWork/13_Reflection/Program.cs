// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Serializer.Benchmarks;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SerializationBenchmarks>();
            Console.WriteLine("Hello, World!");
        }
    }
}


