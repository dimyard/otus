using _30_Patterns.Infrastructure.Repositories;

namespace _30_Patterns.InterfaceAdapters.Controllers;

/// <summary>
/// Controller for mobile phones.
/// </summary>
public class MobilePhoneController
{
    private readonly MobilePhoneRepository _repository;

    public MobilePhoneController(MobilePhoneRepository repository)
    {
        _repository = repository;
    }

    public void ClonePhone(int phoneId)
    {
        var phone = _repository.GetPhoneById(phoneId);
        if (phone != null)
        {
            var clonedPhone = phone.Clone();
            _repository.AddPhone(clonedPhone);
            Console.WriteLine($"Phone cloned: {clonedPhone.ModelName}");
        }
        else
        {
            Console.WriteLine("Phone not found!");
        }
    }
}