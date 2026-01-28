using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class FindRepeatingWords
{
    static void Main(string[] args)
    {
        string input = "This is is a repeated repeated word test.";

        string pattern = @"\b(\w+)\b\s+\1\b";

        HashSet<string> result = new HashSet<string>();

        MatchCollection matches = Regex.Matches(input,pattern);

        foreach(Match match in matches)
        {
           result.Add(match.Groups[1].Value);
        }

        Console.WriteLine(string.Join(", ", result));
    }
}