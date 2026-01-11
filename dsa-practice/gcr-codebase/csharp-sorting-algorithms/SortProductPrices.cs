using System;
class SortProductPrices
{
    public static void QuickSort(int[] Product,int left,int right)
    {
        if(left < right)
        {
            int pivotIndex = Partition(Product,left,right);
            QuickSort(Product,left,pivotIndex-1);
            QuickSort(Product,pivotIndex+1,right);
            
        }
    }

    public static int Partition(int[] Product,int left,int right)
    {
        int pivot = Product[right];
        int i = left - 1;

        for(int j = left; j < right; j++)
        {
            if(Product[j] < pivot)
            {
                i++;
                int temp = Product[i];
                Product[i] = Product[j];
                Product[j] = temp;
            }
        }
        int temp1 = Product[i+1];
        Product[i+1] = Product[right];
        Product[right] = temp1;

        return i+1;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter The Length: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] Product = new int[n];
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Product Prices: ");
            Product[i] = Convert.ToInt32(Console.ReadLine());
        }

        QuickSort(Product,0,Product.Length-1);

        Console.WriteLine("Sorted Product Prices: ");
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine(Product[i]+" ");
        }
    }
}