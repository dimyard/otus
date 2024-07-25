namespace _28_ProcessHandling.Core.Interfaces;

public interface ISumProcessing
{
    long ProcessSum(long[] numbers);
    
    string Title { get; }
}