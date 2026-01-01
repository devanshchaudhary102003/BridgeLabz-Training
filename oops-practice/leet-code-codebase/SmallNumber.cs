using System;

class SmallNumber
{
    static void Main(string[] args)
    {
        // Ask the user for the number of elements in the array
        Console.Write("Enter the number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] nums = new int[n];

        // Take input for the array
        Console.WriteLine("Enter the elements of the array:");
        for (int i = 0; i < n; i++)
        {
            nums[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Call the method to get the answer
        int[] result = SmallerNumbersThanCurrent(nums);

        // Display the result
        Console.WriteLine("Array of counts of smaller numbers:");
        foreach (int count in result)
        {
            Console.Write(count + " ");
        }
        Console.WriteLine();
    }

    // Method to count how many numbers are smaller than the current number
    public static int[] SmallerNumbersThanCurrent(int[] nums)
    {
        int[] ans = new int[nums.Length]; // Array to store the result

        // Loop through each element of nums
        for (int i = 0; i < nums.Length; i++)
        {
            int count = 0; // Reset count for each element

            // Compare nums[i] with every other element
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[i] > nums[j])
                {
                    count++; // Increment if nums[j] is smaller
                }
            }

            ans[i] = count; // Store the count in the answer array
        }

        return ans; // Return the final array
    }
}
