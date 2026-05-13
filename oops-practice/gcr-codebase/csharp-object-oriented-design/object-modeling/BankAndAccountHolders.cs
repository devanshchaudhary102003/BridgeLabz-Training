using System;

//Account class (Links Bank and Customer)
class Account
{
    public int AccountNumber;
    public double Balance;
    public Bank Bank;   // Associated Bank

    public Account(int accNo,double balance, Bank bank)
    {
        AccountNumber = accNo;
        Balance = balance;
        Bank = bank;
    }
}
// Bank class
class Bank
{
    public string BankName;
    private Account[] accounts;
    private int accountCount;

    //Bank Constructor
    public Bank(string bankName)
    {
        BankName = bankName;
        accounts = new Account[10];
        accountCount = 0;
    }

    //Communication method
    public Account OpenAccount(Customer customer, int accNo, double initialBalance)
    {
        Account acc = new Account(accNo,initialBalance,this);
        accounts[accountCount++] = acc;
        customer.AddAccount(acc);

        Console.WriteLine("Account opened for "+customer.CustomerName +" in " + BankName);

        return acc;
    }
}

class Customer
{
    public string CustomerName;
    private Account[] accounts;
    private int accountCount;

    //customer Constructor
    public Customer(string customerName)
    {
        CustomerName = customerName;
        accounts = new Account[5]; // Max 5 accounts
        accountCount = 0;
    }

    public void AddAccount(Account account)
    {
        accounts[accountCount++] = account;
    }

    //Communication Method
    public void ViewBalance()
    {
        Console.WriteLine("Customer Name: "+CustomerName);

        for(int i=0;i<accountCount;i++)
        {
            Console.WriteLine("Bank: "+ accounts[i].Bank.BankName + ", Account No: " +accounts[i].AccountNumber+ ", Balance: "+accounts[i].Balance);
        }
        Console.WriteLine();
    }
}
class BankAndAccountHolders
{
    static void Main(string[] args)
    {   
        // Create multiple banks
        Bank bank1 = new Bank("SBI");
        Bank bank2 = new Bank("HDFC");

        // Create customers
        Customer customer1 = new Customer("Devansh");
        Customer customer2 = new Customer("Rohit");

        // Open accounts in different banks
        bank1.OpenAccount(customer1, 101, 50000);
        bank2.OpenAccount(customer1, 201, 30000);

        bank1.OpenAccount(customer2, 102, 40000);
        bank2.OpenAccount(customer2, 202, 60000);

        // View balances
        customer1.ViewBalance();
        customer2.ViewBalance();
    }
}