using System;
class CelsiustoFahrenheitConversion
{
	static void Main(string[] args)
	{
		int c = Convert.ToInt32(Console.ReadLine());
 		int f = (c*9/5) + 32;
		Console.WriteLine(f);
	}
}