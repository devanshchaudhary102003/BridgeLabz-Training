using System;

class NumberChecker2
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int digitCount = CountDigits(number);
        int[] digits = StoreDigits(number, digitCount);

        Console.WriteLine("Digit Count: " + digitCount);
        Console.Write("Digits: ");
        PrintArray(digits);

        int sum = SumOfDigits(digits);
        Console.WriteLine("Sum of Digits: " + sum);

        int sumSquares = SumOfSquaresOfDigits(digits);
        Console.WriteLine("Sum of Squares of Digits: " + sumSquares);

        bool isHarshad = IsHarshadNumber(number, digits);
        Console.WriteLine("Is Harshad Number: " + isHarshad);

        Console.WriteLine("Digit Frequency:");
        int[,] frequency = FindDigitFrequency(digits);
        for (int i = 0; i < frequency.GetLength(0); i++)
        {
            if (frequency[i, 1] > 0)
                Console.WriteLine("Digit " + frequency[i, 0] + " → " + frequency[i, 1]);
        }
    }

    public static int CountDigits(int number)
    {
        number = Math.Abs(number);
        int count = 0;
        while (number > 0)
        {
            count++;
            number /= 10;
        }
        return count;
    }

    public static int[] StoreDigits(int number, int count)
    {
        int[] digits = new int[count];
        number = Math.Abs(number);

        for (int i = count - 1; i >= 0; i--)
        {
            digits[i] = number % 10;
            number = number / 10;
        }
        return digits;
    }

    public static int SumOfDigits(int[] digits)
    {
        int sum = 0;
        for (int i = 0; i < digits.Length; i++)
            sum = sum + digits[i];
        return sum;
    }

    public static int SumOfSquaresOfDigits(int[] digits)
    {
        int sum = 0;
        for (int i = 0; i < digits.Length; i++)
            sum += (int)Math.Pow(digits[i], 2);
        return sum;
    }

    public static bool IsHarshadNumber(int number, int[] digits)
    {
        int sum = SumOfDigits(digits);
        return sum != 0 && number % sum == 0;
    }

    public static int[,] FindDigitFrequency(int[] digits)
    {
        int[,] freq = new int[10, 2]; 
        for (int i = 0; i < 10; i++)
            freq[i, 0] = i;

        for (int i = 0; i < digits.Length; i++)
            freq[digits[i], 1]++;

        return freq;
    }

    public static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
            Console.Write(arr[i] + " ");
    }
}
