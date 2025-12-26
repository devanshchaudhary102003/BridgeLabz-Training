// LeetCode Problem no 3467 Transform Array By Parity
using System;

class TransformArrayByParity
{
    static void Main(string[] args)
    {
        // Ask user for the length of the array
        Console.WriteLine("Enter the length of the array:");
        int n = Convert.ToInt32(Console.ReadLine());

        // Create the array
        int[] nums = new int[n];

        // Take array elements as input
        Console.WriteLine("Enter the elements:");
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Create answer array
        int[] ans = new int[nums.Length];

        for(int i=0;i<nums.Length;i++){
            if(nums[i]%2==0){
                ans[i] = 0;
            }
            else{
                ans[i] = 1;
            }
        }
        Array.Sort(ans);
        
        // Print the result array
        Console.WriteLine("Result array:");
        for(int i=0;i<ans.Length;i++){
            Console.WriteLine(ans[i]);
        }
    }
}