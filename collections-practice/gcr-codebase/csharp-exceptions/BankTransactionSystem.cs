using System;

// Custom Exception
class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message)
    {
    }
}

// Bank Account Class
class BankAccount
{
    private double balance;

    public BankAccount(double initialBalance)
    {
        balance = initialBalance;
    }

    public void Withdraw(double amount)
    {
        // Negative amount check
        if (amount < 0)
        {
            throw new ArgumentException("Invalid amount!");
        }

        // Insufficient balance check
        if (amount > balance)
        {
            throw new InsufficientFundsException("Insufficient balance!");
        }

        // Successful withdrawal
        balance -= amount;
        Console.WriteLine("Withdrawal successful, new balance: " + balance);
    }
}

// Main Class
class BankTransactionSystem
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount(5000);

        try
        {
            Console.Write("Enter withdrawal amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            account.Withdraw(amount);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}
