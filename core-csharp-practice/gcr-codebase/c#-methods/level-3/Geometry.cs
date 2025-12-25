using System;

class Geometry
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

        double distance = EuclideanDistance(x1, y1, x2, y2);
        Console.WriteLine("\nEuclidean Distance between ({0},{1}) and ({2},{3}) = {4:F4}", x1, y1, x2, y2, distance);

        double[] line = LineEquation(x1, y1, x2, y2);
        if (line == null)
        {
            Console.WriteLine("The line is vertical. Equation: x = " + x1);
        }
        else
        {
             Console.WriteLine("Equation of the line: y = {0:F4}*x + {1:F4}", line[0], line[1]);
        }
    }

    public static double EuclideanDistance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    public static double[] LineEquation(double x1, double y1, double x2, double y2)
    {
        if (x2 == x1)
        {
            return null;
        }

        double slope = (y2 - y1) / (x2 - x1);      
        double intercept = y1 - slope * x1;        
        return new double[] { slope, intercept };
    }
}
