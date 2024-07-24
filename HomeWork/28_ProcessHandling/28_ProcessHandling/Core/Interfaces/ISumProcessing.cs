namespace _28_ProcessHandling.Core.Interfaces;

public interface ISumProcessing
{
    long ProcessSum(int[] numbers);
    
    string Title { get; }
}