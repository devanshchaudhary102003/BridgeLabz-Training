using NUnit.Framework;
using System;

// ======================
// BankAccount Class
// ======================
public class BankAccount
{
    private double balance;

    public void Deposit(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive");

        balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive");

        if (amount > balance)
            throw new InvalidOperationException("Insufficient funds");

        balance -= amount;
    }

    public double GetBalance()
    {
        return balance;
    }
}

// ======================
// NUnit Test Class
// ======================
[TestFixture]
public class BankAccountTests
{
    private BankAccount account;

    [SetUp]
    public void SetUp()
    {
        account = new BankAccount();
    }

    //  Deposit Tests
    [Test]
    public void Deposit_ValidAmount_IncreasesBalance()
    {
        account.Deposit(1000);
        Assert.That(account.GetBalance(), Is.EqualTo(1000));
    }

    //  Withdraw Tests
    [Test]
    public void Withdraw_ValidAmount_DecreasesBalance()
    {
        account.Deposit(1000);
        account.Withdraw(400);

        Assert.That(account.GetBalance(), Is.EqualTo(600));
    }

    //  Insufficient Funds Test
    [Test]
    public void Withdraw_InsufficientFunds_ThrowsException()
    {
        account.Deposit(300);

        Assert.That(
            () => account.Withdraw(500),
            Throws.TypeOf<InvalidOperationException>()
        );
    }

    //  Negative Deposit Test
    [Test]
    public void Deposit_NegativeAmount_ThrowsException()
    {
        Assert.That(
            () => account.Deposit(-100),
            Throws.TypeOf<ArgumentException>()
        );
    }

    //  Negative Withdraw Test
    [Test]
    public void Withdraw_NegativeAmount_ThrowsException()
    {
        Assert.That(
            () => account.Withdraw(-50),
            Throws.TypeOf<ArgumentException>()
        );
    }
}
