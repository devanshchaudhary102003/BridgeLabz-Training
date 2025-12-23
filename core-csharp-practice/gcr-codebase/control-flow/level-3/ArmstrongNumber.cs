using System;
class ArmstrongNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        int OriginalNumber = Number;
        int sum = 0;
        while(OriginalNumber != 0)
        {
            int rem = OriginalNumber % 10;
            sum += rem * rem * rem;
            OriginalNumber = OriginalNumber/10;
        }
        if(sum == Number)
        {
            Console.WriteLine("Armstrong Number");
        }
        else
        {
            Console.WriteLine("Not Armstrong Number");
        }
    }
}