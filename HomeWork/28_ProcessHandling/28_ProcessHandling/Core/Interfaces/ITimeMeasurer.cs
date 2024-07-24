namespace _28_ProcessHandling.Core.Interfaces;

public interface ITimeMeasurer
{
    long Measure(Action action);
}