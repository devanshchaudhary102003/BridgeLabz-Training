using System;
using System.Numerics;
class MissingNumber
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
        
        int max = int.MinValue;
        int sum = 0;
        int result = 0;
        for(int i = 0; i < n; i++)
        {
           max = Math.Max(arr[i],max);
           int ans = ((max)*(max+1))/2;
           sum += arr[i];

            result = ans - sum;
        }
        Console.WriteLine("Missing Number is :"+result);
    }
}