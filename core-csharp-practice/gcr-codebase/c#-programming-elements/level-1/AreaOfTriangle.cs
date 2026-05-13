using System;
class AreaOfTriangle
{
	static void Main(string[] args)
	{
		int b = Convert.ToInt32(Console.ReadLine());
		int h = Convert.ToInt32(Console.ReadLine());
		
		double area = (0.5)*b*h;
		Console.WriteLine("The area of triangle:"+area);
	}
}