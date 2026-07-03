using System;

namespace MyApp;

public class AuthService
{
    private readonly Repository<User> _userRepo;

    public AuthService(Repository<User> userRepo)
    {
        _userRepo = userRepo;
    }

    public void Login(string username, string password)
    {
        User user = _userRepo.GetById((e) => e.Username == username);

        if (user != null)
        {
            if (!user.IsLocked)
            {
                if (user.PasswordHash == password)
                {
                    Console.WriteLine($"Welcome, {user.Username}!");
                    user.FailedLoginAttempts = 0;
                    user.IsLocked = false;
                }
                else
                {
                    ++user.FailedLoginAttempts;
                    if (user.FailedLoginAttempts >= 2)
                    {
                        user.IsLocked = true;
                        throw new Exception("Account locked due to too many failed login attempts.");
                    }
                    throw new Exception("Invalid password.");
                }
            }
            else
            {
                throw new Exception("Account is locked, So Please Refer to the admin to unlock it.");
            }
        }
        else
        {
            throw new AccountNotFoundException();
        }
    }
}