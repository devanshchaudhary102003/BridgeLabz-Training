using System;

class Friend
{
    static void Main(string[] args)
    {
        string[] names = {"Amar","Akbar","Anthony"};
        int[] ages = new int[3];
        double[] heights = new double[3];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Enter age: ");
            ages[i] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter height: ");
            heights[i] = Convert.ToDouble(Console.ReadLine());
        }

        int youngIdx = CalculateYoungestFriend(ages);
        int tallIdx = CalculateTallestFriend(heights);

        Console.WriteLine("Youngest Friend: " + names[youngIdx]);
        Console.WriteLine("Tallest Friend: " + names[tallIdx]);
    }

    public static int CalculateYoungestFriend(int[] ages)
    {
        int minIdx = 0;
        for (int i = 1; i < ages.Length; i++)
        {
            if (ages[i] < ages[minIdx])
            {
                minIdx = i;
            }
        }
        return minIdx;
    }

    public static int CalculateTallestFriend(double[] heights)
    {
        int maxIdx = 0;
        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > heights[maxIdx])
            {
                maxIdx = i;
            }
        }
        return maxIdx;
    }
}
