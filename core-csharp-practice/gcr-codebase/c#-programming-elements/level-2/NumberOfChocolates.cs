using System;
class NumberOfChocolates
{
	static void Main(string[] args)
	{
		int NumberOfChocolates = Convert.ToInt32(Console.ReadLine());
		int NumberOfChildren = Convert.ToInt32(Console.ReadLine());
		
		int result = NumberOfChocolates/NumberOfChildren;
		int answer = NumberOfChocolates%NumberOfChildren;
		
		Console.WriteLine("The number of chocolates each child gets is"+result+" and the number of remaining chocolates is "+answer);
	}
	
}