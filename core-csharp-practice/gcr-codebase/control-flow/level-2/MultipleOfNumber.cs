using System;
class MultipleOfNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        for(int i = 100; i >= 1; i--)
        {
            if(Number % i == 0)
            {
                Console.WriteLine(i);

            }
        }
    }
}