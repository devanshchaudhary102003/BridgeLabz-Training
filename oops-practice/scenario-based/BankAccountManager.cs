using System;
class User
{
    public string UserName;
    public int AccountNumber;
    public int Pin;
    public int Balance;

    public User(string userName,int accountNumber,int pin)
    {
        UserName = userName;
        AccountNumber = accountNumber;
        Pin = pin;
        Balance = 0;
    }

    public void DisplayUserDetails()
    {
        Console.WriteLine("User Name:"+UserName);
        Console.WriteLine("Account Number:"+AccountNumber);
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += (int)amount;
            Console.WriteLine("Amount Deposited: " + amount);
            DisplayBalance();
        }
        else
        {
            Console.WriteLine("Invalid Amount");
        }
    }

    public void WithDraw(double amount)
    {
        if(amount > 0 && amount <= Balance)
        {
            Balance -= (int)amount;
            Console.WriteLine("Withdraw amount:"+amount);
            DisplayBalance();
        }
        else
        {
            Console.WriteLine("Insufficient Balance or Invalid amount.");
        }
    }

    public void DisplayBalance()
    {
        Console.WriteLine("Current Balance:"+Balance);
    }
}
class AccountManager
{
    User user;

    //Create User
    public void CreateAccount()
    {

        Console.Write("Enter User Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter User Account Number: ");
        int accNo = int.Parse(Console.ReadLine());

        Console.Write("Enter User PIN: ");
        int pin = int.Parse(Console.ReadLine());

        user = new User(name,accNo,pin);

        Console.WriteLine("Account Created Successfully...");
    }

    public void ModifyAccount()
    {
        if(user == null)
        {
            Console.WriteLine("No account exists.");
        }
        
        Console.WriteLine("1. Change Name");
        Console.WriteLine("2. Change PIN");
        int choice = int.Parse(Console.ReadLine());

        if(choice == 1)
        {
            Console.WriteLine("Enter New Name:");
            user.UserName = Console.ReadLine();
            Console.WriteLine("Name Updated Successfully...");
            }
            
        else if(choice == 2)
        {
            Console.WriteLine("Enter PIN:");
            user.Pin = int.Parse(Console.ReadLine());
            Console.WriteLine("Pin Updated Successfully...");
        }

        else
        {
            Console.WriteLine("Invalid Choice");
        }
    }

    public void DeleteAccount()
    {
        if(user == null)
        {
            Console.WriteLine("No account to delete");
        }
        else
        {
            user = null;
            Console.WriteLine("Account Deleted Successfully");
        }
    }

    public void DisplayAccount()
    {
        if(user == null)
        {
            Console.WriteLine("No Account Found");
        }
        else
        {
            user.DisplayUserDetails();
            user.DisplayBalance();
        }
    }
    public void UserMenu()
    {
        if(user == null)
        {
            Console.WriteLine("No Account Exists....");
        }

        int ch;
        do
        {
            Console.WriteLine("------- USER MENU ----------");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. View Account");
            Console.WriteLine("4. Back");

            ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    Console.WriteLine("Enter Amount:");
                    user.Deposit(int.Parse(Console.ReadLine()));
                    break;
                
                case 2:
                    Console.WriteLine("Enter Amount:");
                    user.WithDraw(int.Parse(Console.ReadLine()));
                    break;
                
                case 3:
                    user.DisplayUserDetails();
                    break;
                
                case 4:
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }while(ch != 4);
    }
}
class Bank{
    static string BankName = "SBI";
    public string BranchName;
    public string IfscCode;
    public int MinimumBalance;
    public int MaximumTransaction;

    public Bank(string branchName,string ifscCode,int minimumBalance,int maximumTransaction)
    {
        BranchName = branchName;
        IfscCode = ifscCode;
        MinimumBalance = minimumBalance;
        MaximumTransaction = maximumTransaction;
    }
    public void DisplayBankDetails()
    {
        Console.WriteLine("Bank Name:" + BankName);
        Console.WriteLine("Branch Name:"+BranchName);
        Console.WriteLine("IFSC Code:"+IfscCode);
        Console.WriteLine("Minimum Balance:"+MinimumBalance);
        Console.WriteLine("Maximum Transaction:"+MaximumTransaction);
    }

}

class BankAccountManager
{
    static void Main(string[] args)
    {
        AccountManager manager = new AccountManager();
        Bank bank = new Bank("Delhi","SBI000123",2000,100000);

        int choice;

        do
        {
            Console.WriteLine("------------ MAIN MENU ------------");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. User");
            Console.WriteLine("3 Show Bank Details");
            Console.WriteLine("4. Exit");

            Console.Write("Enter Choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n--- MANAGER MENU ---");
                    Console.WriteLine("1. Create Account");
                    Console.WriteLine("2. Modify Account");
                    Console.WriteLine("3. Delete Account");

                    int mChoice = int.Parse(Console.ReadLine());

                    switch (mChoice)
                    {
                        case 1:
                            manager.CreateAccount();
                            break;

                        case 2:
                            manager.ModifyAccount();
                            break;

                        case 3:
                            manager.DeleteAccount();
                            break;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    
                    }
                    break;

                case 2:
                    manager.UserMenu();
                    break;

                case 3:
                    bank.DisplayBankDetails();
                    break;

                case 4:
                    Console.WriteLine("Exiting Program.....");
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        
        }while(choice != 4);
    }
}