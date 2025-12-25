using System;
class Triangular
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Side1(in meters):");
        int Side1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Side2(in meters):");
        int Side2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Side3(in meters):");
        int Side3 = Convert.ToInt32(Console.ReadLine());

        int rounds = CalculateTriangular(Side1,Side2,Side3);

        Console.WriteLine("Number of rounds required to complete 5 km run: " + rounds);
    }
    static int CalculateTriangular(int Side1, int Side2, int Side3)
    {
        int Perimeter = Side1 + Side2 + Side3;
        int TotalDistance = 5000;

        return TotalDistance/Perimeter;
    }
}