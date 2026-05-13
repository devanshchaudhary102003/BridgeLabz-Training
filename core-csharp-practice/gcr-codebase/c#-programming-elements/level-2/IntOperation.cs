using System;
class IntOperation
{
	static void Main(string[] args)
	{
		int a = Convert.ToInt32(Console.ReadLine());
		int b = Convert.ToInt32(Console.ReadLine());
		int c = Convert.ToInt32(Console.ReadLine());
		
		int result1 = a+b*c;
		int result2 = a*b+c;
		int result3 = c+a/b;
		int result4 = a%b+c;
		
		Console.WriteLine("The results of Int Operations are "+result1+","+result2+","+result3+" and"+result4);
	}
}