using System;
class Discount
{
    static void Main(string[] args)
    {
        int Discount = 125000/10;
        int fee = 125000 - Discount;

        Console.WriteLine("The discount amount is INR:"+Discount+"and final discounted fee is INR:"+fee);
    }
}