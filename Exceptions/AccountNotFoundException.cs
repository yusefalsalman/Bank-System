using System;

namespace MyApp;

public class AccountNotFoundException : Exception
{
    public AccountNotFoundException() : base("Account not found.")
    { }
}