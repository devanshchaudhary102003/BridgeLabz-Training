using System;
using System.Diagnostics;

class SortingComparison
{
    static void Main()
    {
        int[] sizes = { 1000, 10000 }; // Bubble Sort not suitable for very large data

        foreach (int size in sizes)
        {
            Console.WriteLine("\nDataset Size: " + size);

            int[] data = GenerateRandomArray(size);

            TestSort("Bubble Sort", BubbleSort, (int[])data.Clone());
            TestSort("Merge Sort", MergeSortWrapper, (int[])data.Clone());
            TestSort("Quick Sort", QuickSortWrapper, (int[])data.Clone());
        }

        Console.ReadLine();
    }

    // ================= TIME MEASUREMENT =================
    static void TestSort(string name, Action<int[]> sortMethod, int[] array)
    {
        Stopwatch sw = Stopwatch.StartNew();
        sortMethod(array);
        sw.Stop();

        Console.WriteLine(name + " Time: " + sw.ElapsedMilliseconds + " ms");
    }

    // ================= BUBBLE SORT =================
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // ================= MERGE SORT =================
    static void MergeSortWrapper(int[] arr)
    {
        MergeSort(arr, 0, arr.Length - 1);
    }

    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, mid + 1, R, 0, n2);

        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
                arr[k++] = L[i++];
            else
                arr[k++] = R[j++];
        }

        while (i < n1)
            arr[k++] = L[i++];

        while (j < n2)
            arr[k++] = R[j++];
    }

    // ================= QUICK SORT =================
    static void QuickSortWrapper(int[] arr)
    {
        QuickSort(arr, 0, arr.Length - 1);
    }

    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);

            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int t = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = t;

        return i + 1;
    }

    // ================= RANDOM DATA =================
    static int[] GenerateRandomArray(int size)
    {
        Random rand = new Random();
        int[] arr = new int[size];

        for (int i = 0; i < size; i++)
            arr[i] = rand.Next(1, 100000);

        return arr;
    }
}
