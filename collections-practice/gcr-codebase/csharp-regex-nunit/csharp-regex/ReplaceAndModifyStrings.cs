using System;
using System.Text.RegularExpressions;
class ReplaceAndModifyStrings
{
    static void Main(string[] args)
    {
        string input = "This   is    an   example                   with   multiple    spaces.";
        string output = Regex.Replace(input, @"\s+", " ");

        Console.WriteLine(output);
    }
}
