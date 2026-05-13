using System;
class MeanHeight
{
    static void Main(string[] args)
    {
        double[] height = new double[11];
        double sum = 0;

        for(int i = 0; i < height.Length; i++)
        {
            Console.WriteLine("Enter Height:");
            height[i] = Convert.ToDouble(Console.ReadLine());
            sum += height[i];
        }
        double mean = sum/height.Length;

        Console.WriteLine("Mean height of the football team:"+mean);
    }
}