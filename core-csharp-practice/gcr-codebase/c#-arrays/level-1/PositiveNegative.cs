using System;
class PositiveNegative
{
    static void Main(string[] args)
    {
        int[] arr = new int[5];
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }
        for(int i = 0; i < arr.Length; i++)
        {
            if(arr[i] > 0)
            {
                if(arr[i] % 2 == 0)
                {
                    Console.WriteLine("Positive Even");
                }
                else
                {
                    Console.WriteLine("Positive Odd");
                }
            }
            else if(arr[i] < 0)
            {
                Console.WriteLine("Negative");
            }
            else
            {
                Console.WriteLine("Zero");
            }
        }
    }
}