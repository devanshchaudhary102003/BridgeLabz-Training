/*There are n employees in a company, numbered from 0 to n - 1. Each employee i has worked for arr[i] arr in the company.
The company requires each employee to work for at least target arr.
You are given a 0-indexed array of non-negative integers arr of length n and a non-negative integer target.
Return the integer denoting the number of employees who worked at least target arr.*/
using System;
class NumberOfEmployeesWhoMetTheTarget
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

        Console.WriteLine("Enter Target:");
        int target = Convert.ToInt32(Console.ReadLine());

        int count = 0;

        for(int i=0;i<arr.Length;i++){
            if(arr[i] >= target){
                count++;
            }
        }
        Console.WriteLine("Result:"+count);
    }
}