using _30_Patterns.Infrastructure.Repositories;
using _30_Patterns.InterfaceAdapters.Presenters;

namespace _30_Patterns.UseCases;

/// <summary>
/// Use case for cloning a mobile phone.
/// </summary>
public class CloneMobilePhoneUseCase
{
    private readonly MobilePhoneRepository _repository;
    private readonly CloneResultPresenter _presenter;

    public CloneMobilePhoneUseCase(MobilePhoneRepository repository, CloneResultPresenter presenter)
    {
        _repository = repository;
        _presenter = presenter;
    }

    public void Execute(int phoneId)
    {
        var phone = _repository.GetPhoneById(phoneId);
        if (phone != null)
        {
            var clonedPhone = phone.Clone();
            _repository.AddPhone(clonedPhone);
            _presenter.Present(phone, clonedPhone);
        }
        else
        {
            Console.WriteLine("Phone not found!");
        }
    }
}