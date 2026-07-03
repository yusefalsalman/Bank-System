using System;

namespace MyApp;

public sealed class Transaction
{
    public DateTime Date { get; }
    public decimal Amount { get; }
    public string Type { get; } // type: "Deposit", "Withdraw", "Transfer"
    public decimal RunningBalance { get; }

    public Transaction(decimal amount, string type, decimal runningBalance)
    {
        Date = DateTime.Now;
        Amount = amount;
        Type = type;
        RunningBalance = runningBalance;
    }
}