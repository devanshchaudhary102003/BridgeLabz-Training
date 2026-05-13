using System;
class GcdLcm
{
    static void Main(string[] args)
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        int gcd = Gcd(a,b);
        int lcm = (a*b)/gcd;

        Console.WriteLine("GCD = "+gcd);
        Console.WriteLine("LCM = "+lcm);
    }
    static int Gcd(int x,int y)
    {
        while(y != 0)
        {
            int temp = y;
            y = x % y;
            x = temp;
        }
        return x;
    }
}