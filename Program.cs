using System;

namespace MyApp;

class Program
{
    static void Main(string[] args)
    {
        Repository<User> userRepo = new Repository<User>();
        Repository<Account> accountRepo = new Repository<Account>();

        AuthService authService = new AuthService(userRepo);
        BankService bankService = new BankService(accountRepo);

        User user1 = new User("user1", "password1", false, false, 0);
        User user2 = new User("user2", "password2", false, false, 0);
        userRepo.Add(user1);
        userRepo.Add(user2);

        Account account1 = new SavingAccount("account1");
        Account account2 = new CheckingAccount("account2");
        accountRepo.Add(account1);
        accountRepo.Add(account2);

        while (true)
        {
            Console.WriteLine("=========== Welcome to the Bank System ===========");
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Exit");

            try
            {
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Enter username:");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter password:");
                    string password = Console.ReadLine();

                    try
                    {
                        authService.Login(username, password);
                        Console.WriteLine("=========== Login successful! ===========");
                        while (true)
                        {
                            Console.WriteLine("=========== Select an option: ===========");
                            Console.WriteLine("1. Deposit");
                            Console.WriteLine("2. Withdraw");
                            Console.WriteLine("3. Transfer");
                            Console.WriteLine("4. View Balance");
                            Console.WriteLine("5. View Transactions");
                            Console.WriteLine("6. Exit");

                            int option = int.Parse(Console.ReadLine());
                            if (option == 1)
                            {
                                Console.WriteLine("Enter account number:");
                                string accountNumber = Console.ReadLine();

                                Console.WriteLine("Enter amount to deposit:");
                                decimal amount = decimal.Parse(Console.ReadLine());
                                try
                                {
                                    bankService.Deposit(accountNumber, amount);
                                    Console.WriteLine("Deposit successful!");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);

                                }
                            }
                            else if (option == 2)
                            {
                                Console.WriteLine("Enter account number:");
                                string accountNumber = Console.ReadLine();

                                Console.WriteLine("Enter amount to Withdraw:");
                                decimal amount = decimal.Parse(Console.ReadLine());
                                try
                                {
                                    bankService.WithDraw(accountNumber, amount);
                                    Console.WriteLine("Withdraw successful!");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else if (option == 3)
                            {
                                Console.WriteLine("Enter Sender account number:");
                                string fromAccountNumber = Console.ReadLine();

                                Console.WriteLine("Enter amount to transfer:");
                                decimal amount = decimal.Parse(Console.ReadLine());

                                Console.WriteLine("Enter reciever account number: ");
                                string toAccountNumber = Console.ReadLine();
                                try
                                {
                                    bankService.Transfer(fromAccountNumber, toAccountNumber, amount);
                                    Console.WriteLine("Transfer successful!");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else if (option == 4)
                            {
                                Console.WriteLine("Enter account number:");
                                string accountNumber = Console.ReadLine();
                                Console.WriteLine($"Balance: {bankService.GetBalance(accountNumber)}");
                            }
                            else if (option == 5)
                            {
                                Console.WriteLine("Enter account number:");
                                string accountNumber = Console.ReadLine();
                                try
                                {
                                    List<Transaction> transactions = bankService.GetTransactions(accountNumber);
                                    foreach (var transaction in transactions)
                                    {
                                        Console.WriteLine($"Date: {transaction.Date}, Type: {transaction.Type}, Amount: {transaction.Amount}, Running Balance: {transaction.RunningBalance}");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else if (option == 6)
                            {
                                Console.WriteLine("Exiting the program.");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Invalid option. Please try again.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Exiting the program.");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}