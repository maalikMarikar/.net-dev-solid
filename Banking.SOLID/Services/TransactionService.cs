using Banking.SOLID.Models;
using Banking.SOLID.Repositories;

namespace Banking.SOLID.Services;

public class TransactionService : ITransactionService
{
    private readonly IAccountRepository _repository;

    public TransactionService(IAccountRepository repository)
    {
        _repository = repository;
    }

    public void Deposit(Account account, float amount)
    {
        account.Balance += amount;
        _repository.Update(account);
        Console.WriteLine($"Deposited {amount} to account {account.Id}. New balance: {account.Balance}");
    }

    public void Withdraw(Account account, float amount)
    {
        if (account.Balance >= amount)
        {
            account.Balance -= amount;
            _repository.Update(account);
            Console.WriteLine($"Withdrew {amount} from account {account.Id}. New balance: {account.Balance}");
        }
        else
        {
            Console.WriteLine($"Insufficient funds for account {account.Id}. Current balance: {account.Balance}");
        }
    }

    public void Transfer(Account from, Account to, float amount)
    {
        if (from.Balance >= amount)
        {
            from.Balance -= amount;
            to.Balance += amount;
            _repository.Update(from);
            _repository.Update(to);
            Console.WriteLine($"Transferred {amount} from account {from.Id} to account {to.Id}");
        }
        else
        {
            Console.WriteLine($"Insufficient funds for account {from.Id}. Transfer failed.");
        }
    }
}