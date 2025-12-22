using System;
class NaturalNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int ans = (number)*(number+1)/2;

        if(number > 0){
            Console.WriteLine("If the number is a positive integer then the output is The sum of "+number+" natural numbers is "+ans);
        }
        else
        {
            Console.WriteLine("The number "+number+" is not a natural number");
        }
    }
}