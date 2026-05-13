using System;
class NumberOfChocolates
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Number of Chocolates:");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Number of Children:");
        int d = Convert.ToInt32(Console.ReadLine());

        int[] result = FindNumberOfChocolates(n,d);
        Console.WriteLine("number of chocolates each child gets: "+result[0]);
        Console.WriteLine("number of remaining chocolates: "+result[1]);
    }

    public static int[] FindNumberOfChocolates(int numberOfchocolates, int numberOfChildren)
    {
        int number = numberOfchocolates/numberOfChildren;
        int RemainingChocolates = numberOfchocolates%numberOfChildren;

        return new int[] { number, RemainingChocolates };
    }
}