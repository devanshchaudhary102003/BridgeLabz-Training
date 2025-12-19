using System;
class Yards
{
	static void Main(string[] args)
	{
		int feet = Convert.ToInt32(Console.ReadLine());
		
		int yard = 3 * feet;
		int mile = 1760 * yard;
		
		Console.WriteLine("Distance in Miles:"+mile);
	}
}