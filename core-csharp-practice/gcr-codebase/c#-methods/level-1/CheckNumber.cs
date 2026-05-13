using System;
class CheckNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Number:");
        int n = Convert.ToInt32(Console.ReadLine());

        int check = CheckNum(n);

        Console.WriteLine(check);
    }
    static int CheckNum(int num)
    {
        if(num < 0)
        {
            return -1;
        }
        else if(num > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}