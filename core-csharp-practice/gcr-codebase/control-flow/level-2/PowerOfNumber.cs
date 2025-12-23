using System;
class PowerOfNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Power:");
        int Power = Convert.ToInt32(Console.ReadLine());

        int result = Number;
        for(int i = 1; i < Power; i++)
        {
            result = result * Number;
        }
        Console.WriteLine("result:"+result);
    }
}