using System;

namespace MyApp;

public class SavingAccount : Account, IInterestBearing
{
    private const decimal MinBalance = 100;
    private decimal InterestRate = 0.025m;
    private int WithdrawalCount = 0;

    public SavingAccount(string ownerName) : base(ownerName) { }

    public override void Withdraw(decimal amount)
    {
        if (WithdrawalCount < 5)
        {
            if (Balance - amount >= MinBalance)
            {
                set_balance(Balance - amount);
                ++WithdrawalCount;
            }
            else
            {
                throw new InsufficientFundsException();
            }
        }
        else
        {
            throw new WithdrawalLimitException();
        }
    }

    public void CalculateInterest()
    {
        decimal value = Balance * InterestRate;
        set_balance(value + Balance);
    }
    public void ApplyMonthlyFees()
    {
        WithdrawalCount = 0;
    }
}