using System;

namespace MyApp;

public class CheckingAccount : Account
{
    private decimal OverDraftLimit = -500;
    public CheckingAccount(string owner) : base(owner) { }

    public override void Withdraw(decimal amount)
    {
        if (Balance - amount >= OverDraftLimit)
        {
            set_balance(Balance - amount);
            if (Balance < 0)
            {
                set_balance(Balance - 10);
            }
        }
        else
        {
            throw new InsufficientFundsException();
        }
    }
}