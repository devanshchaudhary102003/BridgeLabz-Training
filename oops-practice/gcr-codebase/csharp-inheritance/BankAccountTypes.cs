using System;

class BankAccount
{
    public int AccountNumber;
    public double Balance;

    public BankAccount(int accountNumber, double balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public virtual void DisplayAccountType()
    {
        Console.WriteLine("Generic Bank Account");
    }

    public void DisplayBalance()
    {
        Console.WriteLine("Account Number: " + AccountNumber);
        Console.WriteLine("Balance: ₹" + Balance);
    }
}

class SavingsAccount : BankAccount
{
    public double InterestRate;

    public SavingsAccount(int accountNumber, double balance, double interestRate)
        : base(accountNumber, balance)
    {
        InterestRate = interestRate;
    }

    public override void DisplayAccountType()
    {
        Console.WriteLine("Account Type: Savings Account");
        DisplayBalance();
        Console.WriteLine("Interest Rate: " + InterestRate + "%");
        Console.WriteLine();
    }
}

class CheckingAccount : BankAccount
{
    public double WithdrawalLimit;

    public CheckingAccount(int accountNumber, double balance, double withdrawalLimit)
        : base(accountNumber, balance)
    {
        WithdrawalLimit = withdrawalLimit;
    }

    public override void DisplayAccountType()
    {
        Console.WriteLine("Account Type: Checking Account");
        DisplayBalance();
        Console.WriteLine("Withdrawal Limit: ₹" + WithdrawalLimit);
        Console.WriteLine();
    }
}

class FixedDepositAccount : BankAccount
{
    public int LockInPeriod; // in months

    public FixedDepositAccount(int accountNumber, double balance, int lockInPeriod)
        : base(accountNumber, balance)
    {
        LockInPeriod = lockInPeriod;
    }

    public override void DisplayAccountType()
    {
        Console.WriteLine("Account Type: Fixed Deposit Account");
        DisplayBalance();
        Console.WriteLine("Lock-in Period: " + LockInPeriod + " months");
        Console.WriteLine();
    }
}

class BankAccountTypes
{
    static void Main()
    {
        BankAccount[] accounts = new BankAccount[3];

        accounts[0] = new SavingsAccount(101, 50000, 4.5);
        accounts[1] = new CheckingAccount(102, 30000, 10000);
        accounts[2] = new FixedDepositAccount(103, 100000, 24);

        for (int i = 0; i < accounts.Length; i++)
        {
            accounts[i].DisplayAccountType(); // Polymorphism
        }
    }
}
