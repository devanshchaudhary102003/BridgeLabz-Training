using System;
class FactorsOfNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        int maxFactor = 10;
        int[] FactorArr = new int[maxFactor];

        int idx = 0;

        for(int i = 1; i <= Number; i++)
        {
            if(Number % i == 0)
            {
                if(idx == maxFactor)
                {
                    maxFactor = maxFactor * 2;
                    int[] temp = new int[maxFactor];

                    for(int j = 0; j < FactorArr.Length; j++)
                    {
                        temp[j] = FactorArr[j];
                    }
                    FactorArr = temp;
                }
                FactorArr[idx] = i;
                idx++;
            }
        }

        for(int i = 0; i < idx; i++)
        {
            Console.WriteLine("Factors of the Number:"+FactorArr[i]);
        }
    }
}