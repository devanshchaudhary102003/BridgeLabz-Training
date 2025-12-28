/*How Many Numbers Are Smaller Than the Current Number
Given the array arr, for each arr[i] find out how many numbers in the array are smaller than it. That is, for each arr[i] you have to count the number of valid j's such that j != i and arr[j] < arr[i].
Return the answer in an array.*/
using System;
class HowManyNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Length:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];
        for(int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        int[] ans = new int[arr.Length];

        for(int i=0;i<arr.Length;i++){
            int count=0;
            for(int j=0;j<arr.Length;j++){
                if(arr[i] > arr[j]){
                    count++;
                }
            }
            ans[i] = count;
        }
        for(int i = 0; i < ans.Length; i++)
        {
            Console.WriteLine("Result:"+ans[i]);
        }
    }
}