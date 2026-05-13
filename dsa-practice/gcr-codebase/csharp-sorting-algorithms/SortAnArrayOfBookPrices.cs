using System;
class SortAnArrayOfBookPrices
{
    public static void MergeSort(int[] BookPrice,int left, int right)
    {
        if(left < right)
        {
            int mid = (left+right)/2;

            MergeSort(BookPrice,left,mid);
            MergeSort(BookPrice,mid+1,right);

            Merge(BookPrice,left,mid,right);
        }
    }

    public static void Merge(int[] BookPrice,int left,int mid,int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] Left = new int[n1];
        int[] Right = new int[n2];

        for(int i = 0; i < n1; i++)
            Left[i] = BookPrice[left+i];

        for(int j = 0; j < n2; j++)
            Right[j] = BookPrice[mid+1+j];

        int iIndex = 0;
        int jIndex = 0;
        int k = left;

        while(iIndex < n1 && jIndex < n2)
        {
            if(Left[iIndex] <= Right[jIndex])
                BookPrice[k++] = Left[iIndex++];

            else
                BookPrice[k++] = Right[jIndex++];
        }

        while(iIndex < n1)
            BookPrice[k++] = Left[iIndex++];

        while(jIndex < n2)
            BookPrice[k++] = Right[jIndex++];
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter The Length: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] BookPrice = new int[n];
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Book Prices: ");
            BookPrice[i] = Convert.ToInt32(Console.ReadLine());
        }

        MergeSort(BookPrice,0,BookPrice.Length-1);

        Console.WriteLine("Sorted Book Prices: ");
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine(BookPrice[i]+" ");
        }
    }
}