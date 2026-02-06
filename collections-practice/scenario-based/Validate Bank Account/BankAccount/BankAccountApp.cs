using System;

class BankAccountApp
{
    public decimal InitialBalance;

    public BankAccountApp(decimal initialBalance)
    {
        InitialBalance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if(amount < 0)
        {
            throw new Exception("Deposit amount cannot be negative");
        }
        InitialBalance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if(amount > InitialBalance)
        {
            throw new Exception("Insufficient Funds");
        }
        InitialBalance -= amount;
    }
}