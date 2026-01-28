using System;
using System.Text.RegularExpressions;
class ExtractLinks
{
    static void Main(string[] args)
    {
        string input = "Visit https://www.google.com and http://example.org for more info.";

        string pattern = @"https?:\/\/[^\s]+";

        MatchCollection matches = Regex.Matches(input,pattern);

        foreach(Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}