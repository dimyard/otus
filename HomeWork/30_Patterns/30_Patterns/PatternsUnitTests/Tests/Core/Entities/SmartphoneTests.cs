using _30_Patterns.Core.Entities;

namespace _30_Patterns.Tests.Core.Entities;

/// <summary>
/// Unit tests for the <see cref="Smartphone"/> class.
/// </summary>
public class SmartphoneTests
{
    /// <summary>
    /// Tests that the <see cref="Smartphone"/> constructor initializes properties correctly.
    /// </summary>
    [Fact]
    public void Smartphone_ShouldInitializePropertiesCorrectly()
    {
        // Arrange & Act
        var smartphone = new Smartphone("iPhone 13", "Apple", "iOS", 12);

        // Assert
        Assert.Equal("iPhone 13", smartphone.ModelName);
        Assert.Equal("Apple", smartphone.Manufacturer);
        Assert.Equal("iOS", smartphone.OperatingSystem);
        Assert.Equal(12, smartphone.CameraMegapixels);
    }

    /// <summary>
    /// Tests that the <see cref="Smartphone.Clone"/> method returns an exact copy of the original object.
    /// </summary>
    [Fact]
    public void Smartphone_Clone_ShouldReturnExactCopy()
    {
        // Arrange
        var originalSmartphone = new Smartphone("iPhone 13", "Apple", "iOS", 12);

        // Act
        var clonedSmartphone = originalSmartphone.Clone();

        // Assert
        Assert.NotNull(clonedSmartphone);
        Assert.NotSame(originalSmartphone, clonedSmartphone); // Ensure it's a different object
        Assert.Equal(originalSmartphone.ModelName, clonedSmartphone.ModelName);
        Assert.Equal(originalSmartphone.Manufacturer, clonedSmartphone.Manufacturer);
        Assert.Equal(originalSmartphone.OperatingSystem, clonedSmartphone.OperatingSystem);
        Assert.Equal(originalSmartphone.CameraMegapixels, clonedSmartphone.CameraMegapixels);
    }
}