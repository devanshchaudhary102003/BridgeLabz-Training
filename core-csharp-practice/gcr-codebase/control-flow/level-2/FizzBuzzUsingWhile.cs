using System;
class FizzBuzzUsingWhile
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        int i=0;
        while(i < Number)
        {
            i++;
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