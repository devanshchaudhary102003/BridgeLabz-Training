using System;

class SumOfNaturalNumbers
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number <= 0)
        {
            Console.WriteLine("Enter a Natural number.");
        }

        int recursiveSum = SumUsingRecursion(number);

        int formulaSum = SumUsingFormula(number);

        Console.WriteLine("Sum using recursion: " + recursiveSum);
        Console.WriteLine("Sum using formula: " + formulaSum);

        if (recursiveSum == formulaSum)
        {
            Console.WriteLine("Computation is correct.");
        }
        else
        {
            Console.WriteLine("Computation is incorrect.");
        }
    }

    public static int SumUsingRecursion(int n)
    {
        if(n == 1){
            return 1;
        }

        return n + SumUsingRecursion(n - 1);
    }

    public static int SumUsingFormula(int n)
    {
        return n * (n + 1) / 2;
    }
}
