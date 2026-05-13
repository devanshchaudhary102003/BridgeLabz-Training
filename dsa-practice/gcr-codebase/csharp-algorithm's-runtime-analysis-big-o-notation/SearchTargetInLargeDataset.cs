using System;
using System.Diagnostics;
class SearchTargetInLargeDataset
{
    static int LinearSearch(int[] arr,int target)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            if(arr[i] == target)
            {
                return i;
            }
        }
        return -1;
    }

    static int BinarySearch(int[] arr,int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while( left <= right )
        {
            int mid = left + (right - left)/2;

            if(arr[mid] == target)
            {
                return mid;
            }
            else if(arr[mid] < target)
            {
                left = mid + 1 ;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }
    static void Main(string[] args)
    {
        int n = 1000000;    // dataset size
        int target = n - 1; // worst case for linear search

        int[] data = new int[n];

        for(int i = 0; i < n; i++)
        {
            data[i] = i;
        }

        Stopwatch sw = new Stopwatch();

        sw.Start();
        int linerresult = LinearSearch(data,target);
        sw.Stop();
        Console.WriteLine("Linear Search Index: "+linerresult);
        Console.WriteLine("Linear Search Time: "+sw.ElapsedMilliseconds+" ms");

        sw.Restart();
        int binaryresult = BinarySearch(data,target);
        sw.Stop();
        Console.WriteLine("Binary Search Index: "+binaryresult);
        Console.WriteLine("Binary Search Time: "+sw.ElapsedMilliseconds+" ms");

        Console.WriteLine();
    }
}