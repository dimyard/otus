using _30_Patterns.Core.Interfaces;

namespace _30_Patterns.Core.Entities;

/// <summary>
/// Represents a mobile phone.
/// </summary>
public abstract class MobilePhone : Device, IMyCloneable<MobilePhone>
{
    public string OperatingSystem { get; set; }
    
    public int Id { get; set; }

    protected MobilePhone(string modelName, string manufacturer, string operatingSystem)
        : base(modelName, manufacturer)
    {
        OperatingSystem = operatingSystem;
    }

    public abstract MobilePhone Clone();
}