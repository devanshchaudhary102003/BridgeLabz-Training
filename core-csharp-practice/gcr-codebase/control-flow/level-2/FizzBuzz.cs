using System;
class FizzBuzz
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        for(int i = 1; i <= Number; i++)
        {
            if((i % 3 == 0) && (i % 5 == 0))
            {
                Console.WriteLine("FizzBuzz");
                continue;
            }
            if(i % 3 == 0)
            {
                Console.WriteLine("Fizz");
                continue;
            }
            if(i % 5 == 0)
            {
                Console.WriteLine("Buzz");
                continue;
            }
            Console.WriteLine(i);
        }
    }
}