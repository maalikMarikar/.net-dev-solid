SOLID Principles Implementation
1) Single Responsibility Principle (SRP)

Definition: A class should have only one reason to change—each class should do one specific job.

How the current code achieves it:

Account class → only stores account data (Id, OwnerName, Balance, Type)

AccountRepository / InMemoryAccountRepository → only handles data storage, retrieval, and updates

TransactionService → only handles business logic (Deposit, Withdraw, Transfer)

Example:

If we want to change how money is transferred, only TransactionService needs to be updated.

If we want to change how accounts are stored, only the repository classes need updates.

This separation makes the code modular and easy to maintain.

--------------------------------------------------------------------------------------------------------------------------------------------

2) Open/Closed Principle (OCP)

Definition: Classes should be open for extension but closed for modification, can extend behavior without changing existing code.

How current code achieves it:

TransactionService depends on the interface IAccountRepository, not a concrete repository (concrete class)

New repository implementations can be added (like MongoAccountRepository) without modifying TransactionService

Similarly, new types of accounts or services can be added without touching existing classes

Example:

IAccountRepository repo = new InMemoryAccountRepository();
// OR
IAccountRepository repo = new AccountRepository(new BankContext());

-----------------------------------------------------------------------------------------------------------------------------------------------

3) Liskov Substitution Principle (LSP)

Definition: Subtypes must be replaceable for their base types without breaking the program.

How current code achieves it:

Any class implementing IAccountRepository can be used by TransactionService

TransactionService doesn’t care which concrete repository is used: EF Core SQLite, InMemory, or any future repo

This ensures the service behavior is consistent regardless of the repository implementation

Example:

IAccountRepository repo;

// Swap implementations freely:
repo = new AccountRepository(new BankContext());
repo = new InMemoryAccountRepository();

var service = new TransactionService(repo);
service.Deposit(someAccount, 100);

