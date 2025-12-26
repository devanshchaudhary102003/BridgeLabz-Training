// LeetCode Problem no 1920 Build Array From Permutation
using System;
class BuildArrayFromPermutation
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

        // Create answer array
        int[] ans = new int[arr.Length];

        // Build array from permutation
        for(int i=0;i<arr.Length;i++){
            ans[i] = arr[arr[i]];
        }

        // Print the result array
        Console.WriteLine("Result array:");
        for(int i=0;i<ans.Length;i++){
            Console.WriteLine(ans[i]);
        }
    }
}