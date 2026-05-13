using System;
class VolumeofaCylinder
{
	static void Main(string[] args){
		int r = Convert.ToInt32(Console.ReadLine());
		int h = Convert.ToInt32(Console.ReadLine());
		double v = 3.14 * r * r * h;
		Console.WriteLine(v);
	}			
}