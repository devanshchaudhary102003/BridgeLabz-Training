using System;

class PowerCalculation
{
    static void Main(string[] args){
		int b = Convert.ToInt32(Console.ReadLine());
		int e = Convert.ToInt32(Console.ReadLine());

        int res = Math.Pow(b,e);
		Console.WriteLine(res);
	}
}