/* 
You are given an m x n integer grid accounts where:
accounts[i][j] is the amount of money the ith customer has in the jth bank.

A customer's wealth = sum of all bank balances.
Return the maximum wealth among all customers.
*/
using System;
class RichestCustomerWealth
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the rows :");
        int m = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the columns :");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] accounts = new int[m,n];

        // Initialize each row and take input
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                accounts[i,j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        int max = 0; // to store maximum wealth

        // Calculate wealth for each customer
        for (int i = 0; i < m; i++)
        {
            int sum = 0; // wealth of current customer

            for (int j = 0; j < n; j++)
            {
                sum += accounts[i,j];
            }

            // Update maximum wealth
            max = Math.Max(max, sum);
        }

        // Print the richest customer's wealth
        Console.WriteLine("Richest Wealth: " + max);
    }
}
