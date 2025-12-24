using System;
class Frequency
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        long n = Convert.ToInt64(Console.ReadLine());

         int[] frequency = new int[10];

        while (n > 0)
        {
            int digit = (int)(n % 10);
            frequency[digit]++;
            n = n/10;
        }
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Digit"+i+":"+frequency[i]);
        }
    }
}