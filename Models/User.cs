using System;

namespace MyApp;

public class User
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsLocked { get; set; }
    public int FailedLoginAttempts { get; set; }

    public User(string username, string passwordHash, bool isAdmin, bool isLocked, int failedLoginAttempts)
    {
        Username = username;
        PasswordHash = passwordHash;
        IsAdmin = isAdmin;
        IsLocked = isLocked;
        FailedLoginAttempts = failedLoginAttempts;
    }
}