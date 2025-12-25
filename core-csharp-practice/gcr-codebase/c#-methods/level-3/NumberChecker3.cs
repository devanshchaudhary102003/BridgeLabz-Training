using System;

class NumberChecker3
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

        int[] reversed = ReverseDigitsArray(digits);
        Console.Write("Reversed Digits: ");
        PrintArray(reversed);

        bool arraysEqual = AreArraysEqual(digits, reversed);
        Console.WriteLine("Arrays are equal: " + arraysEqual);

        bool isPalindrome = IsPalindrome(digits);
        Console.WriteLine("Is Palindrome Number: " + isPalindrome);

        bool isDuck = IsDuckNumber(digits);
        Console.WriteLine("Is Duck Number: " + isDuck);
    }

    public static int CountDigits(int number)
    {
        number = Math.Abs(number);
        int count = 0;
        while (number > 0)
        {
            count++;
            number = number / 10;
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

    public static int[] ReverseDigitsArray(int[] digits)
    {
        int[] reversed = new int[digits.Length];
        for (int i = 0; i < digits.Length; i++)
            reversed[i] = digits[digits.Length - 1 - i];
        return reversed;
    }

    public static bool AreArraysEqual(int[] a, int[] b)
    {
        if (a.Length != b.Length) return false;
        for (int i = 0; i < a.Length; i++)
            if (a[i] != b[i]) return false;
        return true;
    }

    public static bool IsPalindrome(int[] digits)
    {
        int[] reversed = ReverseDigitsArray(digits);
        return AreArraysEqual(digits, reversed);
    }

    public static bool IsDuckNumber(int[] digits)
    {
        for (int i = 0; i < digits.Length; i++)
            if (digits[i] != 0)
                return true;
        return false;
    }

    public static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
            Console.Write(arr[i] + " ");
    }
}
