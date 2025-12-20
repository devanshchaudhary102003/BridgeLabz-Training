using System;
class TemperatureConversion
{
	static void Main(string[] args)
	{
		double Celsius = Convert.ToDouble(Console.ReadLine());
		double Fahrenheit = ((Celsius)*(1.8))+32;
		
		Console.WriteLine("The "+Celsius+" Celsius is "+Fahrenheit+" Fahrenheit");
		
	}
}