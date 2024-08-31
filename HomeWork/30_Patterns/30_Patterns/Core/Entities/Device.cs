using Patterns.Core.Interfaces;

namespace Patterns.Core.Entities;

/// <summary>
/// Represents a device.
/// </summary>
public class Device : ICloneable, IMyCloneable<Device>
{
    public string ModelName { get; set; }
    public string Manufacturer { get; set; }

    protected Device(string modelName, string manufacturer)
    {
        ModelName = modelName;
        Manufacturer = manufacturer;
    }
    
    // Implement ICloneable.Clone()
    object ICloneable.Clone()
    {
        return Clone();
    }

    // Implement IMyCloneable<Device>.Clone()
    public virtual Device Clone()
    {
        return (Device)MemberwiseClone();
    }
}