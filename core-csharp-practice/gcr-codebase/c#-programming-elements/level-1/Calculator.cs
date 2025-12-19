using System;
class Calculator
{
	static void Main(string[] args)
	{
		double a = Convert.ToDouble(Console.ReadLine());
		double b = Convert.ToDouble(Console.ReadLine());
		
		double add = a + b;
		double sub = a - b;
		double mul = a * b;
		double div = a / b;
		
		Console.WriteLine("The addition, subtraction, multiplication and division value of 2 numbers:"+a+" and "+b+" is "+add+","+sub+","+mul+"and"+div);
	}
}