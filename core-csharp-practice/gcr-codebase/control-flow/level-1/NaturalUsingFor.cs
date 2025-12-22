using System;
class NaturalUsingFor
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int ans = (number)*(number+1)/2;
        int ans2 = 0;
        if(number > 0)
        {
            for(int i = 1; i <= number; i++)
            {
                ans2 = ans2 + i;
            }
        }
        if(ans == ans2)
        {
            Console.WriteLine("Final ans:"+ans);
        }
    
    }
}