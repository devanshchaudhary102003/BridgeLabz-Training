using System;
using System.Collections.Generic;

class WithdrawalRequest
{
    public int AccountId;
    public double Amount;

    public WithdrawalRequest(int accountId, double amount)
    {
        AccountId = accountId;
        Amount = amount;
    }
}

class BankingSystem
{
    // 1) Store account balances
    private Dictionary<int, double> balances = new Dictionary<int, double>();

    // 2) Queue for withdrawal requests
    private Queue<WithdrawalRequest> withdrawalQueue = new Queue<WithdrawalRequest>();

    public void CreateAccount(int accountId, double initialBalance)
    {
        if (balances.ContainsKey(accountId))
        {
            Console.WriteLine("Account already exists: " + accountId);
            return;
        }

        if (initialBalance < 0)
        {
            Console.WriteLine("Initial balance cannot be negative.");
            return;
        }

        balances[accountId] = initialBalance;
        Console.WriteLine("Account created: " + accountId + " Balance: " + initialBalance);
    }

    public void Deposit(int accountId, double amount)
    {
        if (!balances.ContainsKey(accountId))
        {
            Console.WriteLine("Account not found: " + accountId);
            return;
        }

        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be greater than 0.");
            return;
        }

        balances[accountId] = balances[accountId] + amount;
        Console.WriteLine("Deposited " + amount + " into " + accountId + ". New balance: " + balances[accountId]);
    }

    public void EnqueueWithdrawal(int accountId, double amount)
    {
        if (!balances.ContainsKey(accountId))
        {
            Console.WriteLine("Account not found: " + accountId);
            return;
        }

        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be greater than 0.");
            return;
        }

        withdrawalQueue.Enqueue(new WithdrawalRequest(accountId, amount));
        Console.WriteLine("Withdrawal request added -> Account: " + accountId + " Amount: " + amount);
    }

    // 3) Process withdrawal requests (FIFO)
    public void ProcessWithdrawals()
    {
        Console.WriteLine("\n--- Processing Withdrawals (Queue FIFO) ---");

        while (withdrawalQueue.Count > 0)
        {
            WithdrawalRequest req = withdrawalQueue.Dequeue();

            double currentBalance = balances[req.AccountId];

            if (currentBalance >= req.Amount)
            {
                balances[req.AccountId] = currentBalance - req.Amount;
                Console.WriteLine("Withdrawal SUCCESS -> Account: " + req.AccountId +
                                  " Amount: " + req.Amount +
                                  " Remaining: " + balances[req.AccountId]);
            }
            else
            {
                Console.WriteLine("Withdrawal FAILED (Insufficient Balance) -> Account: " + req.AccountId +
                                  " Requested: " + req.Amount +
                                  " Available: " + currentBalance);
            }
        }
    }

    // SortedDictionary to sort customers by balance
    public void DisplayCustomersSortedByBalance()
    {
        // Balance -> list of accounts (handle duplicates)
        SortedDictionary<double, List<int>> sorted = new SortedDictionary<double, List<int>>();

        foreach (KeyValuePair<int, double> pair in balances)
        {
            int accountId = pair.Key;
            double balance = pair.Value;

            if (!sorted.ContainsKey(balance))
            {
                sorted[balance] = new List<int>();
            }
            sorted[balance].Add(accountId);
        }

        Console.WriteLine("\n--- Customers Sorted By Balance (Low to High) ---");
        foreach (KeyValuePair<double, List<int>> entry in sorted)
        {
            double balance = entry.Key;

            for (int i = 0; i < entry.Value.Count; i++)
            {
                Console.WriteLine("Account: " + entry.Value[i] + " Balance: " + balance);
            }
        }
    }
}

class ImplementBankingSystem

{
    static void Main()
    {
        BankingSystem bank = new BankingSystem();

        bank.CreateAccount(101, 5000);
        bank.CreateAccount(102, 2000);
        bank.CreateAccount(103, 5000); // same balance (test duplicates)

        bank.Deposit(102, 1500);

        bank.EnqueueWithdrawal(101, 1000);
        bank.EnqueueWithdrawal(102, 5000);  // will fail
        bank.EnqueueWithdrawal(103, 2000);

        bank.ProcessWithdrawals();

        bank.DisplayCustomersSortedByBalance();
    }
}
