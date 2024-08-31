using Patterns.Core.Interfaces;

namespace Patterns.Core.Entities;

/// <summary>
/// Represents a smartphone.
/// </summary>
public class Smartphone : MobilePhone, ICloneable, IMyCloneable<Smartphone>
{
    public int CameraMegapixels { get; set; }

    public Smartphone(string modelName, string manufacturer, string operatingSystem, int cameraMegapixels)
        : base(modelName, manufacturer, operatingSystem)
    {
        CameraMegapixels = cameraMegapixels;
    }

    // Override Clone method to return Smartphone type
    public new Smartphone Clone()
    {
        return (Smartphone)MemberwiseClone();
    }

    object ICloneable.Clone()
    {
        return Clone();
    }

    Smartphone IMyCloneable<Smartphone>.Clone()
    {
        return Clone();
    }
}