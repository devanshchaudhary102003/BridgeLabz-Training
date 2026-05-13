using System;
class GreatestFactor
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        int GreatestFactor = 1;
        for(int i=1;i<=Number/2;i++)
        {
            if(Number % i == 0)
            {
                GreatestFactor = i;
            }
        }
        Console.WriteLine("Greatest Factor:"+GreatestFactor);
    }
}