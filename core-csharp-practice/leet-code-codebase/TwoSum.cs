// LeetCode Problem 1 Two Sum based on Array
// Find indices of two numbers such that they add up to a given target
using System;
class TwoSum
{
    static void Main(string[] args)
    {
        // Ask user for array length
        Console.WriteLine("Enter the Length:");
        int n = Convert.ToInt32(Console.ReadLine());

        // Create array
        int[] arr = new int[n];

        // Take array elements as input
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Array to store the result indices
        int[] ans = new int[2];

        // Ask user for target value
        Console.WriteLine("Enter the Target:");
        int target = Convert.ToInt32(Console.ReadLine());

        // Brute-force approach using two loops (O(n²))
        for(int i = 0; i < arr.Length; i++)
        {
            for(int j = i + 1; j < arr.Length; j++)
            {
                if((arr[i] + arr[j]) == target)
                {
                    ans[0] = i;
                    ans[1] = j;
                }
            }
        }
        Console.WriteLine(ans[0]);
        Console.WriteLine(ans[1]);
    }
}