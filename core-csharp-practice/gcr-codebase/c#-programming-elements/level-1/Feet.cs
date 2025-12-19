using System;
class Feet
{
	static void Main(string[] args)
	{
		double height = Convert.ToDouble(Console.ReadLine());
		double inches = height/2.54;
		double feet = inches/12;
		
		Console.WriteLine("Your Height in cm is:"+height+"while in feet is:"+feet+"and inches is:"+inches);
	}
}