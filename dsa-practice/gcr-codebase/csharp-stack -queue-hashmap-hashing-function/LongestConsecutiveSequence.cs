using System;
using System.Collections.Generic;

class LongestConsecutiveSequence
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

        int result = LongestConsecutive(nums);
        Console.WriteLine("Longest Consecutive Sequence Length: " + result);
    }

    static int LongestConsecutive(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        HashSet<int> set = new HashSet<int>();

        // Store all elements in HashSet
        for (int i = 0; i < nums.Length; i++)
        {
            set.Add(nums[i]);
        }

        int longest = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            // Check start of sequence
            if (!set.Contains(nums[i] - 1))
            {
                int current = nums[i];
                int count = 1;

                while (set.Contains(current + 1))
                {
                    current++;
                    count++;
                }

                if (count > longest)
                    longest = count;
            }
        }

        return longest;
    }
}
