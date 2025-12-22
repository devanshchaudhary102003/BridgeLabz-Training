using System;
class DivisibleByFive
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Is the number "+number+" divisible by 5? "+(number%5==0));
    }
}