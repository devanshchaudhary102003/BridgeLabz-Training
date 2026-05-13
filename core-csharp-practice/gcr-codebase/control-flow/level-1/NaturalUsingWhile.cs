using System;
class NaturalUsingWhile
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int ans = (number)*(number+1)/2;
        int ans2 = 0;
        if(number > 0)
        {
            while(number > 0)
            {
                ans2 = ans2 + number;
                number--;  
            }
        }
        if(ans == ans2)
        {
            Console.WriteLine("Final ans:"+ans);
        }
    }
}