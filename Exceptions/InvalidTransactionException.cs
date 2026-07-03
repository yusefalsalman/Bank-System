using System;

namespace MyApp;

public class InvalidTransactionException : Exception
{
    public InvalidTransactionException() : base("You cannot deposit a negative amount or withdraw a negative or zero amount.")
    { }
}