using System;
class PerimeterofaRectangle
{
	static void Main(string[] args){
		int l = Convert.ToInt32(Console.ReadLine());
		int b = Convert.ToInt32(Console.ReadLine());
		
		int p = 2 * (l + b);
		Console.WriteLine(p);
	}
}