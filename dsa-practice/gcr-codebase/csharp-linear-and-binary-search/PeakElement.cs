using System;

class PeakElement
{
    static int FindPeak(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] < arr[mid + 1])
                left = mid + 1;   // move right
            else
                right = mid;      // move left
        }

        return left;  // peak index
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter array length:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];

        Console.WriteLine("Enter elements:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        int peakIndex = FindPeak(arr);

        Console.WriteLine("Peak Index: " + peakIndex);
        Console.WriteLine("Peak Element: " + arr[peakIndex]);
    }
}
