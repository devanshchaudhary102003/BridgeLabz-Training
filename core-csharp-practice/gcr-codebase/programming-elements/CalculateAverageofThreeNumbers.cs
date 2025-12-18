using System;
class CalculateAverageofThreeNumbers
{
    static void Main(string[] args){
		int a = Convert.ToInt32(Console.ReadLine());
		int b = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());
		
		double avg = (a+b+c)/3;
		Console.WriteLine(avg);
	}
}