namespace Banking.SOLID.Models;

public class Account
{
    public int Id { get; set; }
    public string Type { get; set; } = "Savings A/C";
    public float Balance { get; set; }
    public string OwnerName { get; set; } = "N/A";
}