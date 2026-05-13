using System;

class NumberChecker
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int digitCount = CountDigits(number);
        int[] digits = StoreDigits(number, digitCount);

        Console.WriteLine("Number of Digits: " + digitCount);

        Console.WriteLine("Digits:");
        for (int i = 0; i < digits.Length; i++)
        {
            Console.Write(digits[i] + " ");
        }

        Console.WriteLine("Is Duck Number: " + IsDuckNumber(digits));
        Console.WriteLine("Is Armstrong Number: " + IsArmstrongNumber(number, digits));

        int[] largest = FindLargestAndSecondLargest(digits);
        Console.WriteLine("Largest Digit: " + largest[0]);
        Console.WriteLine("Second Largest Digit: " + largest[1]);

        int[] smallest = FindSmallestAndSecondSmallest(digits);
        Console.WriteLine("Smallest Digit: " + smallest[0]);
        Console.WriteLine("Second Smallest Digit: " + smallest[1]);
    }

    public static int CountDigits(int number)
    {
        int count = 0;
        number = Math.Abs(number);

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
            number /= 10;
        }
        return digits;
    }

    public static bool IsDuckNumber(int[] digits)
    {
        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] != 0)
                return true;
        }
        return false;
    }

    public static bool IsArmstrongNumber(int number, int[] digits)
    {
        int sum = 0;
        int power = digits.Length;

        for (int i = 0; i < digits.Length; i++)
        {
            sum += (int)Math.Pow(digits[i], power);
        }

        return sum == number;
    }

    public static int[] FindLargestAndSecondLargest(int[] digits)
    {
        int largest = Int32.MinValue;
        int secondLargest = Int32.MinValue;

        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] > largest)
            {
                secondLargest = largest;
                largest = digits[i];
            }
            else if (digits[i] > secondLargest && digits[i] != largest)
            {
                secondLargest = digits[i];
            }
        }
        return new int[] { largest, secondLargest };
    }

    public static int[] FindSmallestAndSecondSmallest(int[] digits)
    {
        int smallest = Int32.MaxValue;
        int secondSmallest = Int32.MaxValue;

        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] < smallest)
            {
                secondSmallest = smallest;
                smallest = digits[i];
            }
            else if (digits[i] < secondSmallest && digits[i] != smallest)
            {
                secondSmallest = digits[i];
            }
        }
        return new int[] { smallest, secondSmallest };
    }
}
