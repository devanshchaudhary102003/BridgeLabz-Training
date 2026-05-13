using System;

class Collinear
{
    static void Main(string[] args)
    {
        Console.Write("Enter x1: ");
        double x1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter y1: ");
        double y1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter x2: ");
        double x2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter y2: ");
        double y2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter x3: ");
        double x3 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter y3: ");
        double y3 = Convert.ToDouble(Console.ReadLine());

        bool collinearSlope = AreCollinearBySlope(x1, y1, x2, y2, x3, y3);
        Console.WriteLine("Collinear by Slope: " + collinearSlope);

        bool collinearArea = AreCollinearByArea(x1, y1, x2, y2, x3, y3);
        Console.WriteLine("Collinear by Area: " + collinearArea);
    }

    public static bool AreCollinearBySlope(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        if ((x2 - x1 == 0 && x3 - x2 == 0) || (x2 - x1 != 0 && x3 - x2 != 0 && (y2 - y1) / (x2 - x1) == (y3 - y2) / (x3 - x2)))
        {
            double slopeAC = (x3 - x1 != 0) ? (y3 - y1) / (x3 - x1) : double.PositiveInfinity;
            double slopeAB = (x2 - x1 != 0) ? (y2 - y1) / (x2 - x1) : double.PositiveInfinity;
            double slopeBC = (x3 - x2 != 0) ? (y3 - y2) / (x3 - x2) : double.PositiveInfinity;
            return slopeAB == slopeBC && slopeBC == slopeAC;
        }
        return false;
    }

    public static bool AreCollinearByArea(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        double area = 0.5 * (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
        return area == 0;
    }
}
