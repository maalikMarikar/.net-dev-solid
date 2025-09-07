using Microsoft.EntityFrameworkCore;
using Banking.SOLID.Models;

namespace Banking.SOLID.Data;

public class BankContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=vault.db");
    }
}