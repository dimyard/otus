using _30_Patterns.Core.Interfaces;

namespace _30_Patterns.Core.Entities;

/// <summary>
/// Represents a feature phone.
/// </summary>
public class FeaturePhone : MobilePhone, ICloneable
{
    public int BatteryLifeHours { get; set; }

    public FeaturePhone(string modelName, string manufacturer, string operatingSystem, int batteryLifeHours)
        : base(modelName, manufacturer, operatingSystem)
    {
        BatteryLifeHours = batteryLifeHours;
    }

    public override FeaturePhone Clone()
    {
        return new FeaturePhone(ModelName, Manufacturer, OperatingSystem, BatteryLifeHours);
    }

    object ICloneable.Clone()
    {
        return Clone();
    }
}