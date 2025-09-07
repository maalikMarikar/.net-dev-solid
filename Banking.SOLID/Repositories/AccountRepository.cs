using Banking.SOLID.Data;
using Banking.SOLID.Models;
using Microsoft.EntityFrameworkCore;

namespace Banking.SOLID.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly BankContext _context;

    public AccountRepository(BankContext context)
    {
        _context = context;
    }

    public void Add(Account account)
    {
        _context.Accounts.Add(account);
        _context.SaveChanges();
    }

    public Account? GetById(int id)
    {
        return _context.Accounts.Find(id);
    }

    public IEnumerable<Account> GetAll()
    {
        return _context.Accounts.ToList();
    }

    public void Update(Account account)
    {
        _context.Accounts.Update(account);
        _context.SaveChanges();
    }
}