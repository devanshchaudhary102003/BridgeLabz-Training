using System;
class BankAccount
{
    public int AccountNumber;      // Accessible everywhere
    protected string AccountHolder;         // Accessible in the same assembly and subclasses
    private int Balance;           // Accessible only within the class

    public BankAccount(int accountNumber,string accountHolder,int balance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        Balance = balance;
    }

    public void GetBalance()
    {
        Console.WriteLine("Balance:"+Balance);
    }

    public void SetBalance(int NewBalance)
    {
        Balance = NewBalance;
        Console.WriteLine("Updated Balance:"+Balance);
    }

    public void DisplayDetails()
    {
        Console.WriteLine("--------------- Bank Details --------------------");
        Console.WriteLine("Account Number:"+AccountNumber);
        Console.WriteLine("Account Holder:"+AccountHolder);
    }
}

class SavingsAccount : BankAccount
{
    public SavingsAccount(int accountNumber,string accountHolder,int balance) : base(accountNumber, accountHolder, balance)
    {
        Console.WriteLine("--------------- SavingAccount Bank Details --------------------");
        //Accessible because AccountNumber is public
        Console.WriteLine("Account Number: "+AccountNumber);

        // Accessible because AccountHolder is protected
        Console.WriteLine("AccountHolder: " + AccountHolder);

        // Not accessible (private)
        //Console.WriteLine(balance);
    }
}
class BankAccountManagement
{
    static void Main(string[] args)
    {
        BankAccount bank = new BankAccount(2215,"Devansh",50000);
        bank.DisplayDetails();
        bank.GetBalance();
        bank.SetBalance(100000);

        SavingsAccount sbank = new SavingsAccount(2278,"Dev",25000);
        sbank.GetBalance();
        sbank.SetBalance(50000);
    }
}