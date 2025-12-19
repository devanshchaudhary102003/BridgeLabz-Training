using System;
class FinalDiscount
{
    static void Main(string[] args)
    {
        int Discount = Convert.ToInt32(Console.ReadLine());
        int fees = Convert.ToInt32(Console.ReadLine());
		
		int dis = fees/10;
		int fee = fees - dis;

        Console.WriteLine("The discount amount is INR:"+dis+"and final discounted fee is INR:"+fee);
    }
}