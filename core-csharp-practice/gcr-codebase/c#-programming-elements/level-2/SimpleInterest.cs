using System;
class SimpleInterest
{
	static void Main(string[] args)
	{
		Double Principal = Convert.ToDouble(Console.ReadLine());
		Double Rate = Convert.ToDouble(Console.ReadLine());
		Double Time = Convert.ToDouble(Console.ReadLine());
		
		Double Result = (Principal*Rate*Time)/100;
		
		Console.WriteLine("The Simple Interest is "+Result+" for Principal "+Principal+",Rate of Interest "+Rate+" and Time "+Time);
	}
}