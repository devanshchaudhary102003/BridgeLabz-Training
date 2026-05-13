using System;
using System.Text.RegularExpressions;
class ExtractAllEmailAddressesFromText
{
    static void Main(string[] args)
    {
        string text = "Contact us at support@example.com and info@company.org";

        string pattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";

        MatchCollection matches = Regex.Matches(text,pattern);

        foreach(Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
