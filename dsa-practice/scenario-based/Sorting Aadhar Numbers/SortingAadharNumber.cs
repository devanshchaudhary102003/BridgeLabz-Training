using System;
class Sort
{
    public long Max(long[] arr)
    {
        int n = arr.Length;
        long max = arr[0];

        for(int i = 0; i < n; i++)
        {
            if(arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }

    public void CountingSort(long[] arr,long exp)
    {
        int n = arr.Length;
        long[] ans = new long[n];
        int[] count = new int[10];

        for(int i = 0; i < n; i++)
        {
            int digit = (int)((arr[i] / exp) % 10);
            count[digit]++;
        }

        for(int i = 1; i < 10; i++)
        {
            count[i] = count[i] + count[i-1];
        }

        for(int i = n - 1; i >= 0; i--)
        {
            int digit = (int)((arr[i]/exp)%10);
            ans[count[digit]-1] = arr[i];
            count[digit]--;
        }

        for(int i = 0; i < n; i++)
        {
            arr[i] = ans[i];
        }
    }

    public void RadixSort(long[] arr)
    {
        long max = Max(arr);

        for(long exp = 1; max / exp > 0; exp *= 10)
        {
            CountingSort(arr,exp);
        }
    }

    public int BinarySearch(long[] arr,long target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while(left <= right)
        {
            int mid = (left+right)/2;

            if(arr[mid] == target)
                return mid;

            else if(arr[mid] < target)
                left = mid + 1;

            else
                right = mid - 1;
        }
        return -1;
    }
}
class SortingAadharNumber
{
    static void Main(string[] args)
    {
        Sort sort = new Sort();
         long[] aadhaarNumbers = {
            123456789012,
            987654321098,
            123456789045,
            456789123456,
            123456789034
        };

        Console.WriteLine("Before Sorting: ");
        for(int i = 0; i < aadhaarNumbers.Length; i++)
        {
            Console.WriteLine(aadhaarNumbers[i]);
        }

        sort.RadixSort(aadhaarNumbers);

        Console.WriteLine("\nAfter Sorting: ");
        for(int i = 0; i < aadhaarNumbers.Length; i++)
        {
            Console.WriteLine(aadhaarNumbers[i]);
        }

        long searchKey = 123456789034;
        int index = sort.BinarySearch(aadhaarNumbers,searchKey);

        if(index != -1)
            Console.WriteLine("\nAAdhar Found At Index: "+index);
        
        else
            Console.WriteLine("\nAAdhar Not Found");
    }
}