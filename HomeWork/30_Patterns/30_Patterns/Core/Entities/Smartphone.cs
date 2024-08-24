using _30_Patterns.Core.Interfaces;

namespace _30_Patterns.Core.Entities;

/// <summary>
/// Represents a smartphone.
/// </summary>
public class Smartphone : MobilePhone, ICloneable
{
    public int CameraMegapixels { get; set; }

    public Smartphone(string modelName, string manufacturer, string operatingSystem, int cameraMegapixels)
        : base(modelName, manufacturer, operatingSystem)
    {
        CameraMegapixels = cameraMegapixels;
    }

    public override Smartphone Clone()
    {
        return new Smartphone(ModelName, Manufacturer, OperatingSystem, CameraMegapixels);
    }

    object ICloneable.Clone()
    {
        return Clone();
    }
}