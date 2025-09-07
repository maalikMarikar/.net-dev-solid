using Banking.SOLID.Models;

namespace Banking.SOLID.Services;

public interface ITransactionService
{
    void Deposit(Account account, float amount);
    void Withdraw(Account account, float amount);
    void Transfer(Account from, Account to, float amount);
}