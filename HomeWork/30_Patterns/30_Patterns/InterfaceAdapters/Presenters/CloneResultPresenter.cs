using _30_Patterns.Core.Entities;

namespace _30_Patterns.InterfaceAdapters.Presenters;

/// <summary>
/// Presenter for the result of cloning a mobile phone.
/// </summary>
public class CloneResultPresenter
{
    public void Present(MobilePhone originalPhone, MobilePhone clonedPhone)
    {
        Console.WriteLine($"Original Phone: {originalPhone.ModelName}, Manufacturer: {originalPhone.Manufacturer}");
        Console.WriteLine($"Cloned Phone: {clonedPhone.ModelName}, Manufacturer: {clonedPhone.Manufacturer}");
    }
}