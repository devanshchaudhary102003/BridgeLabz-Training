using System;

class RandomNumbers
{
    static void Main(string[] args)
    {
        int size = 5;

        int[] numbers = Generate4DigitRandomArray(size);
        double[] result = FindAverageMinMax(numbers);

        Console.WriteLine("Generated Numbers:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }

        Console.WriteLine("Average: " + result[0]);
        Console.WriteLine("Minimum: " + result[1]);
        Console.WriteLine("Maximum: " + result[2]);
    }

    public static int[] Generate4DigitRandomArray(int size)
    {
        int[] arr = new int[size];
        Random random = new Random();

        for (int i = 0; i < size; i++)
        {
            arr[i] = random.Next(1000, 10000);
        }

        return arr;
    }

    public static double[] FindAverageMinMax(int[] numbers)
    {
        int sum = 0;
        int min = numbers[0];
        int max = numbers[0];

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
            min = Math.Min(min, numbers[i]);
            max = Math.Max(max, numbers[i]);
        }

        double average = (double)sum / numbers.Length;

        return new double[] { average, min, max };
    }
}
