using System;
using System.Text.RegularExpressions;
class ExtractCurrency
{
    static void Main(string[] args)
    {
        string text = "The price is $45.99, and the discount is $ 10.50.";
        string pattern = @"\$\s?\d+(?:\.\d{2})?";

        MatchCollection matches = Regex.Matches(text,pattern);

        foreach(Match match in matches)
        {
            Console.WriteLine(match.Value.Trim());
        }
    }
}