using System;
class BankAccount
{
    //static variable
    public static string BankName = "SBI";
    private static int totalAccounts = 0;
    public string AccountHolderName;

    //readonly variable(cannot be changed after constructor)
    public readonly long AccountNumber;

    //constructor using 'this' keyword
    public BankAccount(string AccountHolderName,long AccountNumber)
    {
        this.AccountHolderName = AccountHolderName;
        this.AccountNumber = AccountNumber;
        totalAccounts++;
    }

    public static void GetTotalAccounts()
    {
        Console.WriteLine("Total Accounts: "+totalAccounts);
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Bank Name: "+BankName);
        Console.WriteLine("Account Holder Name: "+AccountHolderName);
        Console.WriteLine("Account Number: "+AccountNumber);
    } 
}
class BankAccountSystem
{
    static void Main(string[] args)
    {
        BankAccount acc1 = new BankAccount("Devansh",2215111583);
        BankAccount acc2 = new BankAccount("Rohit",2215789643);

        // is operator check
        if(acc1 is BankAccount)
        {
            Console.WriteLine("acc1 is a BankAccount object");
            acc1.DisplayDetails();
        }

        Console.WriteLine();

        if(acc2 is BankAccount)
        {
            Console.WriteLine("acc2 is a BankAccount object");
            acc2.DisplayDetails();
        }

        Console.WriteLine();

        // static method call
        BankAccount.GetTotalAccounts();
    }
}