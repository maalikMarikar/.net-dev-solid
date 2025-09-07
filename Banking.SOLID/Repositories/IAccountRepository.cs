using Banking.SOLID.Models;

namespace Banking.SOLID.Repositories;

public interface IAccountRepository
{
    void Add(Account account);
    Account? GetById(int id);
    IEnumerable<Account> GetAll();
    void Update(Account account);
}