using System;

class Football
{
    static void Main(string[] args)
    {
        int size = 11;
        int[] heights = new int[size];

        Random random = new Random();
        for (int i = 0; i < heights.Length; i++)
        {
            heights[i] = random.Next(150, 251);
        }

        Console.WriteLine("Heights of Players :");
        for (int i = 0; i < heights.Length; i++)
        {
            Console.Write(heights[i] + " ");
        }

        int sum = FindSum(heights);
        double mean = FindMean(sum, heights.Length);
        int shortest = FindShortest(heights);
        int tallest = FindTallest(heights);

        Console.WriteLine("Sum of Heights: " + sum);
        Console.WriteLine("Mean Height: " + mean);
        Console.WriteLine("Shortest Height: " + shortest);
        Console.WriteLine("Tallest Height: " + tallest);
    }

    public static int FindSum(int[] heights)
    {
        int sum = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            sum += heights[i];
        }
        return sum;
    }

    public static double FindMean(int sum, int count)
    {
        return (double)sum / count;
    }

    public static int FindShortest(int[] heights)
    {
        int min = heights[0];
        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] < min)
            {
                min = heights[i];
            }
        }
        return min;
    }

    public static int FindTallest(int[] heights)
    {
        int max = heights[0];
        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > max)
            {
                max = heights[i];
            }
        }
        return max;
    }
}
