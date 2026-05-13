using System;
class RotationPoint
{
    static int FindRotationPoint(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;

        // Case: array is not rotated
        if (arr[left] <= arr[right])
            return 0;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            // Check if mid is the smallest element
            if (mid > 0 && arr[mid] < arr[mid - 1])
                return mid;

            // Decide which side to search
            if (arr[mid] > arr[right])
                left = mid + 1;
            else
                right = mid - 1;
        }

        return 0;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter the length:");
        int length = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[length];

        Console.WriteLine("Enter the elements:");
        for (int i = 0; i < length; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        int rotationIndex = FindRotationPoint(arr);

        Console.WriteLine("Rotation Point Index: " + rotationIndex);
        Console.WriteLine("Smallest Element: " + arr[rotationIndex]);
    }
}
