using System;
class Triangular
{
	static void Main(string[] args)
	{
		Double side1 = Convert.ToDouble(Console.ReadLine());
		Double side2 = Convert.ToDouble(Console.ReadLine());
		Double side3 = Convert.ToDouble(Console.ReadLine());
		
		Double Distance = 5;
		Double Perimeter = side1 + side2 + side3;
		Double Rounds = Distance/Perimeter;
		
		Console.WriteLine("The total number of rounds the athlete will run is "+Rounds+" to complete 5 km");
	}
	
}