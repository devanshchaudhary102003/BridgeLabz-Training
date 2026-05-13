using System;
class EduResult
{
    public void MergeSort(int[] arr,int left, int right)
    {
        if(left < right)
        {
            int mid = (left + right)/2;

            MergeSort(arr,left,mid);
            MergeSort(arr,mid+1,right);

            Merge(arr,left,mid,right);
        }
    }

    public void Merge(int[] arr,int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for(int i=0;i<n1;i++)
            L[i] = arr[left + i];

        for(int j=0;j<n2;j++)
            R[j] = arr[mid + 1 + j];

        int iIndex = 0, jIndex = 0, k = left;

        while(iIndex < n1 && jIndex < n2)
        {
            if(L[iIndex] <= R[jIndex])
                arr[k++] = L[iIndex++];

            else
                arr[k++] = R[jIndex++];
        }

        while(iIndex < n1)
            arr[k++] = L[iIndex++];

        while(jIndex < n2)
            arr[k++] = R[jIndex++];
    }
}
class RankSheet
{
    static void Main(string[] args)
    {
        EduResult eduResult = new EduResult();
        int[] district1 = { 45, 90, 75};
        int[] district2 = { 65, 70, 23};
        int[] district3 = { 43, 62, 21};

        int totalSize = district1.Length + district2.Length + district3.Length;
        int[] allMarks = new int[totalSize];

        int index = 0;

        for(int i = 0; i < district1.Length; i++)
        {
            allMarks[index++] = district1[i];
        }

        for(int i = 0; i < district2.Length; i++)
        {
            allMarks[index++] = district2[i];
        }

        for(int i = 0; i < district3.Length; i++)
        {
            allMarks[index++] = district3[i];
        }

        // Apply Merge Sort
        eduResult.MergeSort(allMarks,0,allMarks.Length-1);

        // Final Rank Sheet
        Console.WriteLine("State-wise Rank List:");
        for(int i = 0; i < allMarks.Length; i++)
        {
            Console.WriteLine(allMarks[i]+" ");
        }
    }
}