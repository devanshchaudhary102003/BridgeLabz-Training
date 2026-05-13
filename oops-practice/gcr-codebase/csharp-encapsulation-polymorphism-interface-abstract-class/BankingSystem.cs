using System;
//Interface
interface ILoanable
{
    void ApplyForLoan();
    double CalculateLoanEligibility();
}
abstract class BankAccount
{
    private int accountNumber;
    private string holderName;
    private double balance;

    public int AccountNumber
    {
        get
        {
            return accountNumber;
        }
        set
        {
            accountNumber = value;
        }
    }

    public string HolderName
    {
        get
        {
            return holderName;
        }
        set
        {
            holderName = value;
        }
    }

    public double Balance
    {
        get
        {
            return balance;
        }
        set
        {
            balance = value;
        }
    }

    public void Deposit(double amount)
    {
        if(amount > 0)
        {
            Console.WriteLine("Balance: "+Balance);
            balance += amount;
            Console.WriteLine("Amount Deposited: "+amount);
        }
    }

    public void Withdraw(double amount)
    {
        if(amount > 0 && amount < Balance)
        
        {
            Console.WriteLine("Balance: "+Balance);
            balance -= amount;
            Console.WriteLine("Amount Withdrawn: "+amount);
            Console.WriteLine("Balance: "+Balance);
        }
        else
        {
            Console.WriteLine("Insufficient Balance...");
        }
    }

    public abstract double CalculateInterest(); 

    public void DisplayDetails()
    {
        Console.WriteLine("Account Number: "+AccountNumber);
        Console.WriteLine("Holder Name: "+HolderName);
        Console.WriteLine("Balance: "+Balance);

        Console.WriteLine("Calculate Interest: "+CalculateInterest());
    }
}

class SavingsAccount : BankAccount, ILoanable
{
    public override double CalculateInterest()
    {
        return Balance * 0.04;  //4% interest
    }

    public void ApplyForLoan()
    {
        Console.WriteLine("Savings Account Loan Applied");
    }

    public double CalculateLoanEligibility()
    {
        return Balance * 5; //5 times balance
    }
}

class CurrentAccount : BankAccount, ILoanable
{
    public override double CalculateInterest()
    {
        return Balance * 0.02;  // 2% interest
    }

    public void ApplyForLoan()
    {
        Console.WriteLine("Current Account Loan Applied");
    }

    public double CalculateLoanEligibility()
    {
        return Balance * 10;    //10 times balance
    }
}
class BankingSystem
{
    static void Main(string[] args)
    {
        BankAccount[] bankAccount = new BankAccount[2];

        bankAccount[0] = new SavingsAccount();
        bankAccount[0].AccountNumber = 221545;
        bankAccount[0].HolderName = "Devansh";
        bankAccount[0].Balance = 5000;

        Console.WriteLine("\n--- Transactions for Devansh (Savings) ---");
        bankAccount[0].Deposit(5000);
        bankAccount[0].Withdraw(4000);

        bankAccount[1] = new CurrentAccount();
        bankAccount[1].AccountNumber = 789456;
        bankAccount[1].HolderName = "Rohit";

        Console.WriteLine("\n--- Transactions for Rohit (Current) ---");
        bankAccount[1].Balance = 8000;
        bankAccount[1].Deposit(4000);
        bankAccount[1].Withdraw(6000);

        for(int i = 0; i < bankAccount.Length; i++)
        {
            Console.WriteLine("=================================================");
            bankAccount[i].DisplayDetails();

            ILoanable loan = (ILoanable)bankAccount[i];
            loan.ApplyForLoan();
            Console.WriteLine("Loan Eligibility: "+loan.CalculateLoanEligibility());
        }
    }
}