using System;
using System.Text.RegularExpressions;
class ValidateCardNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Card Number");
        string card = Console.ReadLine();

        string pattern = "^(4\\d{15}|5\\d{15})$";

        if (Regex.IsMatch(card, pattern))
        {
            if(card.StartsWith("4"))
                Console.WriteLine("Valid Visa Card Number");

            else
                Console.WriteLine("Valid MasterCard Number");
        }
        else
        {
            Console.WriteLine("Invalid Card Number");
        }
    }
}