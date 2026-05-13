using System;
class CalculateSimpleInterest
{
	static void Main(string[] args){
		int p = Convert.ToInt32(Console.ReadLine());
		int r = Convert.ToInt32(Console.ReadLine());
		int t = Convert.ToInt32(Console.ReadLine());
		
		double si = (p*r*t)/100;
		Console.WriteLine(si);
	}
	
}