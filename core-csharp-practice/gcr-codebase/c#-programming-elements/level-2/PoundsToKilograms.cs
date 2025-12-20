using System;
class PoundsToKilograms
{
	static void Main(string[] args)
	{
		Double Weight = Convert.ToDouble(Console.ReadLine());
		
		Double Kilograms = Weight/2.2;
		
		Console.WriteLine("The weight of the person in pounds is "+Weight+" and in kg is "+Kilograms);
	}
}