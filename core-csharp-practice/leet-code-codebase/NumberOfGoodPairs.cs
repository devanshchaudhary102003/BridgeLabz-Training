// LeetCode Problem no 1512 Number Of Good Pairs
using System;
class NumberOfGoodPairs
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

        // Variable to store count of good pairs
        int count = 0;

         // Check all possible pairs (i < j)
        for(int i=0;i<arr.Length;i++){
            for(int j=i+1;j<arr.Length;j++){
                // A good pair is when nums[i] == nums[j]
                if(arr[i] == arr[j]){
                    count++;
                }
            }
        }
        Console.WriteLine("Count of good pairs:"+count);
    }
}