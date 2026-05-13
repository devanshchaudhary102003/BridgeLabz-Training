using System;
class MultiplicationSixToNine
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[4];
        int idx = 0;
        for(int i = 6; i <=9; i++)
        {
            arr[idx] = Number * i;
            idx++;
        }

        idx = 0;
        for(int i = 6; i <= 9; i++)
        {
            Console.WriteLine(Number+" * "+i+" = "+arr[idx]);
            idx++;
        }
    }
}