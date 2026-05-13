using System;
class Income
{
	static void Main(string[] args)
	{
		int Salary = Convert.ToInt32(Console.ReadLine());
		int Bonus = Convert.ToInt32(Console.ReadLine());
		
		int TotalIncome = Salary + Bonus;
		
		Console.WriteLine(" The salary is INR "+Salary+" and bonus is INR "+Bonus+". Hence Total Income is INR "+TotalIncome);
	}
}