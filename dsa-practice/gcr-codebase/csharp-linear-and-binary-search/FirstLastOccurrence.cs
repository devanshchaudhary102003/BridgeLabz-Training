using System;

class FirstLastOccurrence
{
    static int FindFirst(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;
        int result = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
            {
                result = mid;
                right = mid - 1; // move left
            }
            else if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return result;
    }

    static int FindLast(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;
        int result = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
            {
                result = mid;
                left = mid + 1; // move right
            }
            else if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter array length:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];
        Console.WriteLine("Enter sorted elements:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Enter target element:");
        int target = Convert.ToInt32(Console.ReadLine());

        int first = FindFirst(arr, target);
        int last = FindLast(arr, target);

        if (first == -1)
            Console.WriteLine("Target not found");
        else
        {
            Console.WriteLine("First Occurrence Index: " + first);
            Console.WriteLine("Last Occurrence Index: " + last);
        }
    }
}
