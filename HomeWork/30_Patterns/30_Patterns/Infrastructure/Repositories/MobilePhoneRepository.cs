using _30_Patterns.Core.Entities;

namespace _30_Patterns.Infrastructure.Repositories;

/// <summary>
/// Repository for mobile phones.
/// </summary>
public class MobilePhoneRepository
{
    private List<MobilePhone> _phones = new List<MobilePhone>();

    public void AddPhone(MobilePhone phone)
    {
        _phones.Add(phone);
    }

    public MobilePhone? GetPhoneById(int id)
    {
        return _phones.FirstOrDefault(phone => phone.Id == id);
    }

    public List<MobilePhone> GetAllPhones()
    {
        return _phones;
    }
}