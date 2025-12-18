using System;
class ConvertKilometerstoMiles
{
    static void Main(string[] args){
		int km = Convert.ToInt32(Console.ReadLine());
		
		double miles = km * 0.621317;
		Console.WriteLine(miles);
	}
}