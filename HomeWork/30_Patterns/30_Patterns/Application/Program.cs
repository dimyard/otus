using Patterns.Core.Entities;

// Simple test to demonstrate the Prototype pattern 😶‍🌫️

// See unit tests for more comprehensive testing 💁

Smartphone originalSmartphone = new Smartphone("Galaxy S21", "Samsung", "Android", 108);
Smartphone? clonedSmartphone = originalSmartphone.Clone();

Console.WriteLine($"Original Smartphone: Model={originalSmartphone.ModelName}, Manufacturer={originalSmartphone.Manufacturer}, OS={originalSmartphone.OperatingSystem}, Camera={originalSmartphone.CameraMegapixels}MP");
Console.WriteLine($"Cloned Smartphone: Model={clonedSmartphone?.ModelName}, Manufacturer={clonedSmartphone?.Manufacturer}, OS={clonedSmartphone?.OperatingSystem}, Camera={clonedSmartphone?.CameraMegapixels}MP");

FeaturePhone originalFeaturePhone = new FeaturePhone("Nokia 3310", "Nokia", "Series 20", 72);
FeaturePhone clonedFeaturePhone = originalFeaturePhone.Clone();

Console.WriteLine($"Original Feature Phone: Model={originalFeaturePhone.ModelName}, Manufacturer={originalFeaturePhone.Manufacturer}, OS={originalFeaturePhone.OperatingSystem}, Battery Life={originalFeaturePhone.BatteryLifeHours} hours");
Console.WriteLine($"Cloned Feature Phone: Model={clonedFeaturePhone.ModelName}, Manufacturer={clonedFeaturePhone.Manufacturer}, OS={clonedFeaturePhone.OperatingSystem}, Battery Life={clonedFeaturePhone.BatteryLifeHours} hours");