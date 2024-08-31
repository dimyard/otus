using Patterns.Core.Entities;
using Patterns.Core.Interfaces;

namespace Patterns.Tests.Core.Entities;

/// <summary>
/// Unit tests for the <see cref="Smartphone"/> class.
/// </summary>
public class SmartphoneTests
{
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

    [Fact]
    public void Smartphone_Clone_ShouldReturnExactCopy()
    {
        // Arrange
        var originalSmartphone = new Smartphone("iPhone 13", "Apple", "iOS", 12);

        // Act
        var clonedSmartphone = originalSmartphone.Clone();

        // Assert
        Assert.NotNull(clonedSmartphone);
        Assert.NotSame(originalSmartphone, clonedSmartphone);
        Assert.Equal(originalSmartphone.ModelName, clonedSmartphone.ModelName);
        Assert.Equal(originalSmartphone.Manufacturer, clonedSmartphone.Manufacturer);
        Assert.Equal(originalSmartphone.OperatingSystem, clonedSmartphone.OperatingSystem);
        Assert.Equal(originalSmartphone.CameraMegapixels, clonedSmartphone.CameraMegapixels);
    }
    
    [Fact]
    public void CloneDeviceUsingIMyCloneable_ShouldCloneCorrectly()
    {
        // Arrange
        IMyCloneable<Smartphone> smartphone = new Smartphone("iPhone 13", "Apple", "iOS", 12);

        // Act
        var clonedSmartphone = smartphone.Clone();

        // Assert
        Assert.NotNull(clonedSmartphone);
        Assert.IsType<Smartphone>(clonedSmartphone);
        Assert.NotSame(smartphone, clonedSmartphone);
        Assert.Equal(((Smartphone)smartphone).ModelName, clonedSmartphone.ModelName);
        Assert.Equal(((Smartphone)smartphone).Manufacturer, clonedSmartphone.Manufacturer);
        Assert.Equal(((Smartphone)smartphone).OperatingSystem, clonedSmartphone.OperatingSystem);
        Assert.Equal(((Smartphone)smartphone).CameraMegapixels, clonedSmartphone.CameraMegapixels);
    }

    [Fact]
    public void CloneDeviceUsingIMyCloneable_ShouldNotAffectOriginalObjectWhenModified()
    {
        // Arrange
        IMyCloneable<Smartphone> smartphone = new Smartphone("iPhone 13", "Apple", "iOS", 12);
        var clonedSmartphone = smartphone.Clone();

        // Act
        ((Smartphone)smartphone).ModelName = "iPhone 14";
        ((Smartphone)smartphone).Manufacturer = "Apple Inc.";
        ((Smartphone)smartphone).OperatingSystem = "iOS 16";
        ((Smartphone)smartphone).CameraMegapixels = 16;

        // Assert that the cloned object has not changed
        Assert.NotEqual(((Smartphone)smartphone).ModelName, clonedSmartphone.ModelName);
        Assert.NotEqual(((Smartphone)smartphone).Manufacturer, clonedSmartphone.Manufacturer);
        Assert.NotEqual(((Smartphone)smartphone).OperatingSystem, clonedSmartphone.OperatingSystem);
        Assert.NotEqual(((Smartphone)smartphone).CameraMegapixels, clonedSmartphone.CameraMegapixels);
    }

    [Fact]
    public void Smartphone_Clone_ShouldNotAffectOriginal()
    {
        // Arrange
        var originalSmartphone = new Smartphone("iPhone 13", "Apple", "iOS", 12);
        var clonedSmartphone = originalSmartphone.Clone();

        // Act
        clonedSmartphone.CameraMegapixels = 16;

        // Assert
        Assert.NotEqual(originalSmartphone.CameraMegapixels, clonedSmartphone.CameraMegapixels);
        Assert.Equal(12, originalSmartphone.CameraMegapixels);
        Assert.Equal(16, clonedSmartphone.CameraMegapixels);
    }
}