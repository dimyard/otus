using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using Newtonsoft.Json;
using Serializer.Interfaces;
using Serializer.Models;
using Serializer.Services;

namespace Serializer.Benchmarks;

public class CustomConfig : ManualConfig
{
    public CustomConfig()
    {
        AddJob(Job.Default
                .WithIterationCount(10)
                .WithWarmupCount(2)    
                .WithMinIterationCount(100) 
                .WithMaxIterationCount(1000) 
                .WithStrategy(RunStrategy.Throughput)
        );
        AddDiagnoser(BenchmarkDotNet.Diagnosers.MemoryDiagnoser.Default);
    }
}


[Config(typeof(CustomConfig))]
public class SerializationBenchmarks
{
    private F _f;
    private ISerializer<F> _reflectionSerializer;

    [GlobalSetup]
    public void Setup()
    {
        _f = new F().Get();
        _reflectionSerializer = new ReflectionSerializer<F>();
    }

    [Benchmark]
    public string OwnReflectionSerialization()
    {
        return _reflectionSerializer.Serialize(_f);
    }

    [Benchmark]
    public string NewsoftJsonSerialization()
    {
        return JsonConvert.SerializeObject(_f);
    }

    [Benchmark]
    public string SystemTextJsonSerialization()
    {
        return System.Text.Json.JsonSerializer.Serialize(_f);
    }
    
    [Benchmark]
    public F OwnReflectionDeserialization()
    {
        var serialized = _reflectionSerializer.Serialize(_f);
        return _reflectionSerializer.Deserialize(serialized);
    }

    [Benchmark]
    public F NewtonsoftJsonDeserialization()
    {
        var serialized = JsonConvert.SerializeObject(_f);
        return JsonConvert.DeserializeObject<F>(serialized);
    }

    [Benchmark]
    public F SystemTextJsonDeserialization()
    {
        var serialized = System.Text.Json.JsonSerializer.Serialize(_f);
        return System.Text.Json.JsonSerializer.Deserialize<F>(serialized);
    }
}