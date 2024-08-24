namespace _30_Patterns.Core.Entities;

/// <summary>
/// Represents a device.
/// </summary>
public class Device
{
    public string ModelName { get; set; }
    public string Manufacturer { get; set; }

    protected Device(string modelName, string manufacturer)
    {
        ModelName = modelName;
        Manufacturer = manufacturer;
    }
}