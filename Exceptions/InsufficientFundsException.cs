using System;

namespace MyApp;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException() : base("You do not have sufficient funds for this transaction.")
    { }
}