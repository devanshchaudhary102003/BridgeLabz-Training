using System;
class PerimeterOfSquare
{
	static void Main(string[] args)
	{
		int side = Convert.ToInt32(Console.ReadLine());
		
		int peri = side * side;
		
		Console.WriteLine(" The length of the side is: "+side+" whose perimeter is: "+peri);
	}
}