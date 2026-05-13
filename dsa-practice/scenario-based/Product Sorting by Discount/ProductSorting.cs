using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
class ProductSorting
{
    public void QuickSort(int[] arr,int low,int high)
    {
        if(low < high)
        {
            int PivotIndex = Partition(arr,low,high);

            QuickSort(arr,low,PivotIndex-1);
            QuickSort(arr,PivotIndex+1,high);
        }
    }

    public int Partition(int[] arr,int low,int high)
    {
        int Pivot = arr[high];  //pivot element
        int i = low - 1;

        for(int j = low; j < high; j++)
        {
            if(arr[j] < Pivot)
            {
                i++;

                //Swap
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        //swap pivot to correct position
        int temp2 = arr[i+1];
        arr[i+1] = arr[high];
        arr[high] = temp2;

        return i+1;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter The Length: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];
        for(int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        ProductSorting productSorting = new ProductSorting();
        productSorting.QuickSort(arr,0,n-1);

        Console.WriteLine("Sorted Array: ");
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine(arr[i]+" ");
        }
    }

}