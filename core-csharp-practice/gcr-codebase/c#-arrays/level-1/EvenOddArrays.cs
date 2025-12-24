using System;
class EvenOddArrays
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        if(Number <= 0)
        {
            Console.WriteLine("Error:Enter a Natural Number");
        }

        int size = Number/2+1;
        int[] EvenArray = new int[size];
        int[] OddArray = new int[size];
        int EvenIdx = 0;
        int OddIdx = 0;

        for(int i = 0; i < Number; i++)
        {
            if(i % 2 == 0)
            {
                EvenArray[EvenIdx] = i;
                EvenIdx++;

            }
            else
            {
                OddArray[OddIdx] = i;
                OddIdx++;
            }
        }

        for(int i = 0; i < OddIdx; i++)
        {
            Console.WriteLine("Odd Numbers are:"+OddArray[i]);
        }

        for(int i = 0; i < EvenIdx; i++)
        {
            Console.WriteLine("Even Numbers are:"+EvenArray[i]);
        }
    }
}