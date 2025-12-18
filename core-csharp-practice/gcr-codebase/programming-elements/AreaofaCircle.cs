using System;
class AreaofaCircle
{
	static void Main(string[] args)
	{
		int r = Convert.ToInt32(Console.ReadLine());;
		double area = 3.14 * r * r;
		Console.WriteLine(area);
	}
}