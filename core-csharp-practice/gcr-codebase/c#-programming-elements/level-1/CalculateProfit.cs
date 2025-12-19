using System;
class CalculateProfit
{
    static void Main(string[] args)
    {
        int cp = 129;
        int sp = 191;
        Console.WriteLine("The Cost Price is INR:"+cp+"and Selling Price is INR:"+sp);

        int Profit = sp - cp;
        int ProPerc = Profit*100/cp;

        Console.WriteLine("The Profit is INR:"+Profit+ "and the Profit Percentage is:"+ProPerc); 
    }
}