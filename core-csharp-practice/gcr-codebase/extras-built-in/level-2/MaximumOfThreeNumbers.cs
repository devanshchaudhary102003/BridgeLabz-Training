using System;
class MaximumOfThreeNumbers
{
    static void Main(string[] args)
    {
        int a = ReadInt("Enter First Number:");
        int b = ReadInt("Enter Second Number:");
        int c = ReadInt("Enter Third Number:");

        Console.WriteLine("Maximum Number is:"+FindMax(a,b,c));
    }
    static int ReadInt(string message)
    {
        Console.Write(message);
        return Convert.ToInt32(Console.ReadLine());
    }

    static int FindMax(int a,int b, int c)
    {
        return Math.Max(a,Math.Max(b,c));
    }
}