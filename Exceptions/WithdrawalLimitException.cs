using System;

namespace MyApp;

public class WithdrawalLimitException : Exception
{
    public WithdrawalLimitException() : base("Withdrawal amount exceeds the daily limit.")
    { }
}