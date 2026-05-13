using System;
class CountTheNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        int count = 0;
        while(Number != 0)
        {
            Number = Number/10;
            count++;
        }
        Console.WriteLine("Count no. of Digits:"+count);
    }
}