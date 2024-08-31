using Patterns.Core.Interfaces;

namespace Patterns.Core.Entities;

/// <summary>
/// Represents a mobile phone.
/// </summary>
public abstract class MobilePhone : Device, ICloneable, IMyCloneable<MobilePhone>
{
    public string OperatingSystem { get; set; }
    
    public int Id { get; set; }

    protected MobilePhone(string modelName, string manufacturer, string operatingSystem)
        : base(modelName, manufacturer)
    {
        OperatingSystem = operatingSystem;
    }

// Override Clone method to return MobilePhone type
    public new virtual MobilePhone Clone()
    {
        return (MobilePhone)MemberwiseClone();
    }

    object ICloneable.Clone()
    {
        return Clone();
    }

    MobilePhone IMyCloneable<MobilePhone>.Clone()
    {
        return Clone();
    }
}