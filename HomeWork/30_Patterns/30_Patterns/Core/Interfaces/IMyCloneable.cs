namespace _30_Patterns.Core.Interfaces;

/// <summary>
/// Interface for cloning objects.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IMyCloneable<out T>
{
    T Clone();
}