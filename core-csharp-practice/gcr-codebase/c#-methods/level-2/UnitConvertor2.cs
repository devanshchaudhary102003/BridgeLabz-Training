using System;
class UnitConvertor2
{
    public static double ConvertYardsToFeet(double yards)
    {
        double yards2feet = 3;
        return yards * yards2feet;
    }
    public static double ConvertFeetToYards(double feet)
    {
        double feet2yards = 0.333333;
        return feet * feet2yards;
    }

    public static double ConvertMetersToInches(double meters)
    {
        double meters2inches = 39.3701;
        return meters * meters2inches;
    }

    public static double ConvertInchesToMeters(double inches)
    {
        double inches2meters = 0.0254;
        return inches * inches2meters;
    }

    public static double ConvertInchesToCentimeters(double inches)
    {
        double inches2cm = 2.54;
        return inches * inches2cm;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("10 yards to feet: " + UnitConvertor2.ConvertYardsToFeet(10));
        Console.WriteLine("20 feet to yards: " + UnitConvertor2.ConvertFeetToYards(20));
        Console.WriteLine("30 meters to inches: " + UnitConvertor2.ConvertMetersToInches(30));
        Console.WriteLine("40 inches to meters: " + UnitConvertor2.ConvertInchesToMeters(40));
        Console.WriteLine("50 inches to centimeters: " + UnitConvertor2.ConvertInchesToCentimeters(50));
    }
}
