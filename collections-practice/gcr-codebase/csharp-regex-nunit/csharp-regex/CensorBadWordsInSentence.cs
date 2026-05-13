using System;
using System.Text.RegularExpressions;
class CensorBadWordsInSentence
{
    static void Main(string[] args)
    {
        string sentence = "This is a damn bad example with some stupid words.";
        string[] badWords = { "damn", "stupid" };

        foreach(string word in badWords)
        {
            sentence = Regex.Replace(sentence,"\\b" + word + "\\b","****",RegexOptions.IgnoreCase);
        }
        Console.WriteLine(sentence);
    }
}
