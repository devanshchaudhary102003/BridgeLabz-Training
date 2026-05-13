using System;
class HarshadNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        int OriginalNumber = Number;
        int sum = 0;
        while(Number > 0)
        {
            int rem = Number%10;
            sum = sum + rem;
            Number = Number/10;
        }
        if(OriginalNumber % sum == 0)
        {
            Console.WriteLine("Harshad Number");
        }
        else
        {
            Console.WriteLine("Not Harshad Number");
        }
    }
}