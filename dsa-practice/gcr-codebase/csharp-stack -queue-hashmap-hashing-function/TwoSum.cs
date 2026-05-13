using System;
using System.Collections.Generic;

class TwoSum
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());

        int[] nums = new int[n];

        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter target sum: ");
        int target = int.Parse(Console.ReadLine());

        int[] result = TwoSumIndices(nums, target);

        if (result[0] == -1)
            Console.WriteLine("No valid pair found");
        else
            Console.WriteLine("Indices: " + result[0] + ", " + result[1]);
    }

    static int[] TwoSumIndices(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int remaining = target - nums[i];

            if (map.ContainsKey(remaining))
            {
                return new int[] { map[remaining], i };
            }

            // Store current value with index
            if (!map.ContainsKey(nums[i]))
                map.Add(nums[i], i);
        }

        return new int[] { -1, -1 };
    }
}
