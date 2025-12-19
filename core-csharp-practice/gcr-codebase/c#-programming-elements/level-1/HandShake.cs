using System;
class HandShake
{
	static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		int ans = (n*(n+1))/2;
		
		Console.WriteLine(" the number of possible handshakes:"+ans);
	}
}