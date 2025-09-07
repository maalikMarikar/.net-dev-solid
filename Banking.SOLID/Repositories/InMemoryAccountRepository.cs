using Banking.SOLID.Models;

namespace Banking.SOLID.Repositories;

public class InMemoryAccountRepository : IAccountRepository
{
    private readonly List<Account> _accounts = new();
    private int _nextId = 1;

    public void Add(Account account)
    {
        account.Id = _nextId++;
        _accounts.Add(account);
    }

    public Account? GetById(int id)
    {
        return _accounts.FirstOrDefault(a => a.Id == id);
    }

    public IEnumerable<Account> GetAll()
    {
        return _accounts;
    }

    public void Update(Account account)
    {
        var existing = GetById(account.Id);
        if (existing != null)
        {
            existing.Balance = account.Balance;
            existing.OwnerName = account.OwnerName;
            existing.Type = account.Type;
        }
    }
}