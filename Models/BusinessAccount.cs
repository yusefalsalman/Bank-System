using System;

namespace MyApp;

public class BussinessAccount : Account, IInterestBearing
{
    private const decimal OverDraftLimit = -5000;

    public List<string> AuthorizedUsers { get; }

    public BussinessAccount(string ownerName) : base(ownerName)
    {
        AuthorizedUsers = new List<string>();
    }

    public override void Deposit(decimal amount)
    {
        if (amount > 1000)
        {
            set_balance((Balance + amount) + (amount * 0.01m));
        }
        else
        {
            set_balance(Balance + amount);
        }
    }

    public override void Withdraw(decimal amount)
    {
        if (Balance - amount >= OverDraftLimit)
        {
            set_balance(Balance - amount);
        }
        else
        {
            throw new InsufficientFundsException();
        }
    }

    public void CalculateInterest() { }
    public void ApplyMonthlyFees()
    {
        set_balance(Balance - 25m);
    }
}