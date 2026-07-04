# Advanced Bank Account Management System

A robust, multi-layered console-based Banking Application built using **C#** and **.NET**. This project was specifically designed to master core **Object-Oriented Programming (OOP)** principles, advanced architectural patterns, and defensive programming techniques in backend development.

---

## 🚀 Key Learning Objectives & Met Concepts

During the development of this system, I successfully implemented and mastered the following software engineering concepts:

- **Advanced OOP Principles:**
  - **Inheritance & Polymorphism:** Created a base abstract `Account` class and extended it with specialized behaviors for `SavingsAccount`, `CheckingAccount`, and `BusinessAccount` through method overriding.
  - **Abstraction & Interfaces:** Enforced financial rules (like monthly fees and interest logic) across specific account types using the `IInterestBearing` interface.
  - **Encapsulation:** Protected critical state properties (like `Balance`) using `private set` and `protected` access modifiers to prevent unauthorized external mutations.
- **Generic Repository Pattern:** Engineered a reusable, type-safe `Repository<T>` to handle in-memory data persistence, separating data access logic from business rules.
- **LINQ & Lambda Expressions:** Utilized dynamic predicate filtering (`Func<T, bool>`) to handle robust records searching inside generics.
- **Defensive Programming & Exception Handling:** Built robust security rules (e.g., locking a user account after 3 failed login attempts) and created custom bank exceptions (`InsufficientFundsException`, `WithdrawalLimitException`) with proper `try-catch` blocks to prevent application crashes.

---

## 🏗️ Architectural Overview

The project is structured following the **Separation of Concerns (SoC)** principle across distinct layers:

```text
📦 Bank-System
 ┣ 📂 Models       # Domain Models (Account, SavingsAccount, CheckingAccount, BusinessAccount, User, Transaction)
 ┣ 📂 Interfaces   # Architectural Contracts (IInterestBearing)
 ┣ 📂 Exceptions   # Custom Financial Exceptions
 ┣ 📂 Services     # Business & Security Logic (BankService, AuthService, Repository<T>)
 ┗ 📜 Program.cs   # Presentation Layer (Console UI & Global Exception Catching)
```

💼 Domain & Business Rules Implemented
Savings Account: Requires a strict minimum balance of $100. Throws an exception if withdrawals exceed 5 times a month. Automatically calculates monthly interest.

Checking Account: Supports Overdraft Protection down to -$500. Automatically charges a flat $10 fee the moment the balance drops below $0.

Business Account: Supports an extended overdraft limit down to -$5,000, deducts a $25 monthly fee, and rewards a 1% cashback on deposits exceeding $1,000.

Security & Auth Service: Securely manages user authentication with sequential password validation and immediate account lockouts on consecutive failures.

🛠️ Technologies Used
Language: C# 10 / .NET 6 (or higher)

Paradigm: Object-Oriented Programming (OOP)

Data Handling: LINQ & In-Memory Generics

🎯 How to Run the Project
Clone the repository:

Bash
git clone [https://github.com/yusefalsalman/Bank-System.git](https://github.com/yusefalsalman/Bank-System)
Navigate to the project directory:

Bash
cd Bank-System
Run the application using the .NET CLI:

Bash
dotnet run --project Console.UI
