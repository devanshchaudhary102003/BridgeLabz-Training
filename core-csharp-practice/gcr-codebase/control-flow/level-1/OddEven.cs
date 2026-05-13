using System;
class OddEven
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        
        for(int i = 0; i <= number; i++)
        {
            if(i % 2 == 0)
            {
                Console.WriteLine("Even Number:"+i);
            }
            else
            {
                Console.WriteLine("Odd Number:"+i);
            }
        }
    }
}
