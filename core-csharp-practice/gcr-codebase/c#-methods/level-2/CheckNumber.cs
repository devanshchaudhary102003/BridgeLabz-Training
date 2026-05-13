using System;

class CheckNumber
{
    static void Main(string[] args)
    {
        int[] arr = new int[5];
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("Enter number: ");
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        for (int i = 0; i < arr.Length; i++)
        {
            if (CalculatePositive(arr[i]))
            {
                if (CalculateEven(arr[i]))
                {
                    Console.WriteLine(arr[i] + " is Positive and Even");
                }
                else
                {
                    Console.WriteLine(arr[i] + " is Positive and Odd");
                }
            }
            else
            {
                Console.WriteLine(arr[i] + " is Negative");
            }
        }

        int comparisonResult = Compare(arr[0], arr[arr.Length - 1]);

        if (comparisonResult == 1)
        {
            Console.WriteLine("First element is Greater than Last element");
        }
        else if (comparisonResult == 0)
        {
            Console.WriteLine("First element is Equal to Last element");
        }
        else
        {
            Console.WriteLine("First element is Less than Last element");
        }
    }

    public static bool CalculatePositive(int n)
    {
        return n >= 0;
    }

    public static bool CalculateEven(int n)
    {
        return n % 2 == 0;
    }

    public static int Compare(int n1, int n2)
    {
        if(n1 > n2)
        {
            return 1;
        }
        else if(n1 == n2)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
}
