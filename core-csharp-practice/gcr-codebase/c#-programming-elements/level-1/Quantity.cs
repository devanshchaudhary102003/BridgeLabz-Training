using System;
class Quantity
{
	static void Main(string[] args)
	{
		int unitPrice = Convert.ToInt32(Console.ReadLine());
		int quantity = Convert.ToInt32(Console.ReadLine());
		
		int totalPrice = quantity*unitPrice;
		
		Console.WriteLine("The total purchase price is INR: "+unitPrice+" if the quantity: "+quantity+" and unit price is INR: "+totalPrice);
	}
}