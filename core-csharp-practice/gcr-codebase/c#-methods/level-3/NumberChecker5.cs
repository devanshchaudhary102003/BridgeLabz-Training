using System;

class NumberChecker5
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Number: " + number);

        int[] factors = FindFactors(number);
        Console.Write("Factors: ");
        PrintArray(factors);

        int greatest = FindGreatestFactor(factors);
        Console.WriteLine("Greatest Factor: " + greatest);

        int sumFactors = SumOfFactors(factors);
        Console.WriteLine("Sum of Factors: " + sumFactors);

        long productFactors = ProductOfFactors(factors);
        Console.WriteLine("Product of Factors: " + productFactors);

        double productCube = ProductOfCubes(factors);
        Console.WriteLine("Product of Cube of Factors: " + productCube);
        Console.WriteLine("Is Perfect Number: " + IsPerfect(number));
        Console.WriteLine("Is Abundant Number: " + IsAbundant(number));
        Console.WriteLine("Is Deficient Number: " + IsDeficient(number));
        Console.WriteLine("Is Strong Number: " + IsStrong(number));
    }

    public static int[] FindFactors(int number)
    {
        int count = 0;
        for (int i = 1; i <= number; i++)
            if (number % i == 0) count++;

        int[] factors = new int[count];
        int index = 0;
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                factors[index++] = i;
            }
        }
        return factors;
    }

    public static int FindGreatestFactor(int[] factors)
    {
        int max = Int32.MinValue;
        for (int i = 0; i < factors.Length; i++)
            if (factors[i] > max) max = factors[i];
        return max;
    }

    public static int SumOfFactors(int[] factors)
    {
        int sum = 0;
        for (int i = 0; i < factors.Length; i++)
            sum += factors[i];
        return sum;
    }

    public static long ProductOfFactors(int[] factors)
    {
        long product = 1;
        for (int i = 0; i < factors.Length; i++)
            product *= factors[i];
        return product;
    }

    public static double ProductOfCubes(int[] factors)
    {
        double product = 1;
        for (int i = 0; i < factors.Length; i++)
            product *= Math.Pow(factors[i], 3);
        return product;
    }

    public static bool IsPerfect(int number)
    {
        int sum = 0;
        for (int i = 1; i < number; i++)
            if (number % i == 0) sum += i;
        return sum == number;
    }

    public static bool IsAbundant(int number)
    {
        int sum = 0;
        for (int i = 1; i < number; i++)
            if (number % i == 0) sum += i;
        return sum > number;
    }

    public static bool IsDeficient(int number)
    {
        int sum = 0;
        for (int i = 1; i < number; i++)
            if (number % i == 0) sum += i;
        return sum < number;
    }

    public static bool IsStrong(int number)
    {
        int sum = 0;
        int n = number;
        while (n > 0)
        {
            int digit = n % 10;
            sum += Factorial(digit);
            n /= 10;
        }
        return sum == number;
    }

    public static int Factorial(int n)
    {
        int fact = 1;
        for (int i = 1; i <= n; i++)
            fact *= i;
        return fact;
    }

    public static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
            Console.Write(arr[i] + " ");
    }
}
