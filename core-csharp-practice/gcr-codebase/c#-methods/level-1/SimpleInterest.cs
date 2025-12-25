using System;
class SimpleInterest
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Principal:");
        double Principal = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter Rate:");
        double Rate = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter Time:");
        double Time = Convert.ToDouble(Console.ReadLine());

        double Interest = CalculateSimpleInterest(Principal,Rate,Time);

        Console.WriteLine("The Simple Interest is "+Interest+" for Principal "+Principal+" Rate of Interest "+Rate+" and Time "+Time);

    }
        static double CalculateSimpleInterest(double Principle,double Rate,double Time)
        {
            return (Principle*Rate*Time)/100;
        }
}