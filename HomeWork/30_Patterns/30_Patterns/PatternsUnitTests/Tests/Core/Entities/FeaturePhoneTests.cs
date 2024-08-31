using Patterns.Core.Entities;

namespace Patterns.Tests.Core.Entities;

/// <summary>
/// Unit tests for the <see cref="FeaturePhone"/> class.
/// </summary>
public class FeaturePhoneTests
{
    [Fact]
    public void FeaturePhone_ShouldInitializePropertiesCorrectly()
    {
        // Arrange & Act
        var featurePhone = new FeaturePhone("Nokia 3310", "Nokia", "Series 20", 72);

        // Assert
        Assert.Equal("Nokia 3310", featurePhone.ModelName);
        Assert.Equal("Nokia", featurePhone.Manufacturer);
        Assert.Equal("Series 20", featurePhone.OperatingSystem);
        Assert.Equal(72, featurePhone.BatteryLifeHours);
    }

    [Fact]
    public void FeaturePhone_Clone_ShouldReturnExactCopy()
    {
        // Arrange
        var originalFeaturePhone = new FeaturePhone("Nokia 3310", "Nokia", "Series 20", 72);

        // Act
        var clonedFeaturePhone = originalFeaturePhone.Clone();

        // Assert
        Assert.NotNull(clonedFeaturePhone);
        Assert.NotSame(originalFeaturePhone, clonedFeaturePhone); // Ensure it's a different object
        Assert.Equal(originalFeaturePhone.ModelName, clonedFeaturePhone.ModelName);
        Assert.Equal(originalFeaturePhone.Manufacturer, clonedFeaturePhone.Manufacturer);
        Assert.Equal(originalFeaturePhone.OperatingSystem, clonedFeaturePhone.OperatingSystem);
        Assert.Equal(originalFeaturePhone.BatteryLifeHours, clonedFeaturePhone.BatteryLifeHours);
    }

    [Fact]
    public void FeaturePhone_Clone_ShouldNotAffectOriginal()
    {
        // Arrange
        var originalFeaturePhone = new FeaturePhone("Nokia 3310", "Nokia", "Series 20", 72);
        var clonedFeaturePhone = originalFeaturePhone.Clone();

        // Act
        clonedFeaturePhone.BatteryLifeHours = 80;

        // Assert
        Assert.NotEqual(originalFeaturePhone.BatteryLifeHours, clonedFeaturePhone.BatteryLifeHours);
        Assert.Equal(72, originalFeaturePhone.BatteryLifeHours);
        Assert.Equal(80, clonedFeaturePhone.BatteryLifeHours);
    }
}