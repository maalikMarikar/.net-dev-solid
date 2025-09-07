using Banking.SOLID.Data;
using Banking.SOLID.Models;
using Banking.SOLID.Repositories;
using Banking.SOLID.Services;

namespace Banking.SOLID;

class Program
{
    static void Main()
    {
        // (DIP + LSP)
        Console.WriteLine("Choose repository type: 1 = EF Core, 2 = InMemory");
        var choice = Console.ReadLine();
        IAccountRepository repo;

        if (choice == "1")
        {
            var db = new BankContext();
            db.Database.EnsureCreated(); 
            repo = new AccountRepository(db);
        }
        else
        {
            repo = new InMemoryAccountRepository();
        }

        // (DI + SRP) 
        var transactionService = new TransactionService(repo);

        //Menu
        while (true)
        {
            Console.WriteLine("\n--- Banking Menu ---");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. List Accounts");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. Transfer");
            Console.WriteLine("0. Exit");
            Console.Write("Choose: ");
            var input = Console.ReadLine();

            if (input == "0") break;

            switch (input)
            {
                case "1":
                    Console.Write("Owner Name: ");
                    var owner = Console.ReadLine();
                    var account = new Account { OwnerName = owner };
                    repo.Add(account);
                    Console.WriteLine($"Account created with ID {account.Id}");
                    break;

                case "2":
                    foreach (var a in repo.GetAll())
                        Console.WriteLine($"ID: {a.Id}, Owner: {a.OwnerName}, Balance: {a.Balance}");
                    break;

                case "3":
                    Console.Write("Account ID: ");
                    var depId = int.Parse(Console.ReadLine()!);
                    var depAcc = repo.GetById(depId);
                    if (depAcc != null)
                    {
                        Console.Write("Amount to deposit: ");
                        var amount = float.Parse(Console.ReadLine()!);
                        transactionService.Deposit(depAcc, amount);
                    }
                    break;

                case "4":
                    Console.Write("Account ID: ");
                    var witId = int.Parse(Console.ReadLine()!);
                    var witAcc = repo.GetById(witId);
                    if (witAcc != null)
                    {
                        Console.Write("Amount to withdraw: ");
                        var amount = float.Parse(Console.ReadLine()!);
                        transactionService.Withdraw(witAcc, amount);
                    }
                    break;

                case "5":
                    Console.Write("From Account ID: ");
                    var fromId = int.Parse(Console.ReadLine()!);
                    Console.Write("To Account ID: ");
                    var toId = int.Parse(Console.ReadLine()!);
                    var fromAcc = repo.GetById(fromId);
                    var toAcc = repo.GetById(toId);
                    if (fromAcc != null && toAcc != null)
                    {
                        Console.Write("Amount to transfer: ");
                        var amount = float.Parse(Console.ReadLine()!);
                        transactionService.Transfer(fromAcc, toAcc, amount);
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

