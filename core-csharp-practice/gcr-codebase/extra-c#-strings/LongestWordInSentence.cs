using System;
using System.Numerics;
class LongestWordInSentence
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a String:");
        string str = Console.ReadLine();

        string[] words = str.Split(' ');
        string longest = "";

        foreach(string word in words)
        {
            if(word.Length > longest.Length)
            {
                longest = word;
            }
        }
        Console.WriteLine("Longest word in a Sentence: "+longest);
    }
}