using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
class WordFrequencyCounter
{
    static void Main(string[] args)
    {
        string text = "Hello world, hello Java!";

        // Convert to LowerCase
        text = text.ToLower();

        // Remove Punctuation Using Regex
        text = Regex.Replace(text, "[^a-z ]", "");

        //Split words
        string[] words = text.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);

        //Dictionary to store frequency
        Dictionary<string,int> frequency = new Dictionary<string, int>();

        for(int i = 0; i < words.Length; i++)
        {
            if (frequency.ContainsKey(words[i]))
            {
                frequency[words[i]]++;
            }
            else
            {
                frequency[words[i]] = 1;
            }
        }

        foreach(var pair in frequency)
        {
            Console.WriteLine(pair.Key+" : "+pair.Value);
        }    
    }
}