using System;
class LinearSearchSentence
{
    static void Main(string[] args)
    {
        string[] sentences = {"I love programming","C# is a powerful language","Linear Search is easy to understand"};

        string wordToSearch = "Search";
        
        for(int i = 0; i < sentences.Length; i++)
        {
            if (sentences[i].Contains(wordToSearch))
            {
                Console.WriteLine("Word Found in Sentence: "+sentences[i]);
                break;
            }
            else
            {
                Console.WriteLine("Not Available");
            }
        }
    }
}