using System;
using System.Text.RegularExpressions;
class ValidateSSN
{
    static void Main(string[] args)
    {
        string input = "My SSN is 123-45-6789.";

        string pattern = @"\b\d{3}-\d{2}-\d{4}\b";

        Match match = Regex.Match(input,pattern);

        if (match.Success)
        {
            Console.WriteLine("\"" + match.Value + "\" is valid");
        }
        else
        {
            Console.WriteLine("SSN is invalid");
        }

        string noHyphen = "123456789";
        Console.WriteLine(Regex.IsMatch(noHyphen, pattern)
            ? " \"" + noHyphen + "\" is valid"
            : " \"" + noHyphen + "\" is invalid");
    }
}