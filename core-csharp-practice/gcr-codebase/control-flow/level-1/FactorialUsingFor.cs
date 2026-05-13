using System;
class FactorialUsingFor
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int ans = 1;
        for(int i = 1; i <=number; i++)
        {
            ans = ans * i;
        }
        Console.WriteLine(ans);
    }
}
