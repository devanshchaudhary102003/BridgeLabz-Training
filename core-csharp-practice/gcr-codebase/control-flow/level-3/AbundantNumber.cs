using System;
class AbundantNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        int sum = 0;
        for(int i = 1; i < Number; i++)
        {
            if(Number % i == 0)
            {
                sum = sum + i;
            }
        }
        if(sum > Number)
        {
            Console.WriteLine("Abundant Number");
        }
        else
        {
            Console.WriteLine("Not Abundant Number");
        }
    }
}