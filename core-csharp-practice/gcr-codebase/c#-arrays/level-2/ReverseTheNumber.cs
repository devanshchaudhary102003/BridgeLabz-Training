using System;
class ReverseTheNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        int temp =  Number;
        int count = 0;

        while(temp > 0)
        {
            count++;
            temp = temp/10;
        }

        int[] arr = new int[count];
        temp = Number;

        for(int i = 0; i < count; i++)
        {
            arr[i] = temp % 10;
            temp = temp/10;
        }

        for(int i = 0; i < count; i++)
        {
            Console.Write(arr[i]);
        }
        Console.WriteLine();
    }
}