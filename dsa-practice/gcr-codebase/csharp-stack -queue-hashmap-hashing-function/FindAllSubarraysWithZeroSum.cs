using System;
using System.Collections.Generic;

class FindAllSubarraysWithZeroSum
{
    static void CheckZeroSum(int[] arr)
    {
        HashSet<int> set = new HashSet<int>();
        int sum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            sum = sum + arr[i];

            // If prefix sum repeats or becomes zero
            if (sum == 0 || set.Contains(sum))
            {
                Console.WriteLine("Zero sum subarray exists");
                return;
            }

            set.Add(sum);
        }

        Console.WriteLine("No zero sum subarray exists");
    }

    static void Main()
    {
        Console.Write("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];

        Console.WriteLine("Enter elements:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        CheckZeroSum(arr);
    }
}
