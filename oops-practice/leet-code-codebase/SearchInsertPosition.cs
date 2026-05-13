using System;

class SearchInsertPosition
{
    static void Main()
    {
        // Input size of array
        Console.Write("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] nums = new int[n];

        // Input array elements
        Console.WriteLine("Enter sorted array elements:");
        for (int i = 0; i < n; i++)
        {
            nums[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Input target
        Console.Write("Enter target value: ");
        int target = Convert.ToInt32(Console.ReadLine());

        // Call method
        int result = SearchInsert(nums, target);

        // Output
        Console.WriteLine("Target should be inserted at index: " + result);
    }

    // Logic method
    public static int SearchInsert(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (target <= nums[i])
            {
                return i;
            }
        }
        return nums.Length;
    }
}
