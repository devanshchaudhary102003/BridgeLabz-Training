using System;
class Factorial
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int ans = 1;
        int i = 1;
        while(i < number)
        {
            i++;
            ans = ans * i;
        }
        Console.WriteLine(ans);
    }
}
