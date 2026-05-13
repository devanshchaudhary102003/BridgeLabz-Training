using System;
class MultiplicationTable
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[10];
        for(int i = 1; i <=arr.Length; i++)
        {
            arr[i-1] = Number * i;
        }

        for(int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(+Number+" * "+(i+1)+" = "+arr[i]);
        }
    }
}