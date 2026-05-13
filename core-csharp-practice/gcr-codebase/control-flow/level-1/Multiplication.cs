using System;
class Multiplication
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if(number>=6 && number <= 9)
        {
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine(+number+" * "+i+" = "+(number * i));
            }
        }
    }
}