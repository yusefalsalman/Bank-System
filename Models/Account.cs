using System;
using System.Transactions;

namespace MyApp;

public abstract class Account
{
    // public static string BankName;
    public static int TotalAccountCount;
    protected static int NextAccoutNumber = 1000;

    public string AccountNumber { get; }
    public string OwnerName { get; set; }
    public decimal Balance { get; private set; }

    public List<Transaction> TransactionsHistory { get; }

    public Account(string ownerName)
    {
        AccountNumber = NextAccoutNumber.ToString();
        OwnerName = ownerName;
        Balance = 0m;
        NextAccoutNumber++;
        TotalAccountCount++;
        TransactionsHistory = new List<Transaction>();
    }

    public void set_balance(decimal value)
    {
        Balance = value;
    }
    public virtual void Deposit(decimal amount)
    {
        Balance += amount;
    }
    public override string ToString()
    {
        return $"\nAccount N0: {AccountNumber}, Owner Name: {OwnerName}, Balance: {Balance}\n";
    }
    public abstract void Withdraw(decimal amount);
}