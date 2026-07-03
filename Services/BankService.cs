using System;

namespace MyApp;

public class BankService
{
    public readonly Repository<Account> _accountRepo;

    public BankService(Repository<Account> accountRepo)
    {
        _accountRepo = accountRepo;
    }

    public Account GetAccount(string accountNumber)
    {
        var account = _accountRepo.GetById(e => e.AccountNumber == accountNumber);
        return account;
    }

    public void Deposit(string accountNumber, decimal amount)
    {
        var account = GetAccount(accountNumber);
        if (account == null)
        {
            throw new AccountNotFoundException();
        }
        account.Deposit(amount);
        account.TransactionsHistory.Add(new Transaction(amount, "Deposit", account.Balance));
    }

    public void WithDraw(string accountNumber, decimal amount)
    {
        var account = GetAccount(accountNumber);
        if (account == null)
        {
            throw new AccountNotFoundException();
        }
        account.Withdraw(amount);
        account.TransactionsHistory.Add(new Transaction(amount, "Withdraw", account.Balance));
    }

    public List<Transaction> GetTransactions(string accountNumber)
    {
        var account = GetAccount(accountNumber);
        return account.TransactionsHistory;
    }
    public void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount)
    {
        var from_account = GetAccount(fromAccountNumber);
        var to_account = GetAccount(toAccountNumber);
        if (from_account == null || to_account == null)
        {
            throw new AccountNotFoundException();
        }
        from_account.Withdraw(amount);
        to_account.Deposit(amount);
        from_account.TransactionsHistory.Add(new Transaction(amount, "Transfer", from_account.Balance));
        to_account.TransactionsHistory.Add(new Transaction(amount, "Transfer", to_account.Balance));
    }

    public decimal GetBalance(string accountNumber)
    {
        var account = GetAccount(accountNumber);
        return account.Balance;
    }
}