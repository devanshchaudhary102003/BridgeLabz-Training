using System;
class Quotient
{
	static void Main(string[] args)
	{
		int a = Convert.ToInt32(Console.ReadLine());
		int b = Convert.ToInt32(Console.ReadLine());
		
		int q = a/b;
		int r = a%b;
		
		Console.WriteLine("The Quotient is "+q+" and Remainder is "+r+" of two numbers "+a+" and "+b);
	}
}