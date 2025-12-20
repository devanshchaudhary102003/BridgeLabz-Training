using System;
class TemperatureConversionFToC
{
	static void Main(string[] args)
	{
		double Fahrenheit = Convert.ToDouble(Console.ReadLine());
		double Celsius = (Fahrenheit-32)*(0.55);
		
		Console.WriteLine("The "+Fahrenheit+" Fahrenheit is "+Celsius+" Celsius");
		
	}
}