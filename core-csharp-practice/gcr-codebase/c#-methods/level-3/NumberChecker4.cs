using System;

class NumberChecker4
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nNumber: " + number);

        Console.WriteLine("Calculate Prime Number: " + CalculatePrime(number));
        Console.WriteLine("Calculate Neon Number: " + CalculateNeon(number));
        Console.WriteLine("Calculate Spy Number: " + CalculateSpy(number));
        Console.WriteLine("Calculate Automorphic Number: " + CalculateAutomorphic(number));
        Console.WriteLine("Calculate Buzz Number: " + CalculateBuzz(number));
    }

    public static bool CalculatePrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    public static bool CalculateNeon(int number)
    {
        int square = number * number;
        int sum = 0;

        while (square > 0)
        {
            sum += square % 10;
            square = square/10;
        }

        return sum == number;
    }

    public static bool CalculateSpy(int number)
    {
        int sum = 0, product = 1;
        int n = number;

        while (n > 0)
        {
            int digit = n % 10;
            sum = sum + digit;
            product = product * digit;
            n = n / 10;
        }

        return sum == product;
    }

    public static bool CalculateAutomorphic(int number)
    {
        int square = number * number;
        string numStr = number.ToString();
        string squareStr = square.ToString();

        return squareStr.EndsWith(numStr);
    }

    public static bool CalculateBuzz(int number)
    {
        return number % 7 == 0 || number % 10 == 7;
    }
}
