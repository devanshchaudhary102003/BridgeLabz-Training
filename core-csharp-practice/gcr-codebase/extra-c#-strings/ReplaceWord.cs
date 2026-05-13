using System;
class ReplaceWord
{
    static void Main(string[] args)
    {
        Console.Write("Enter a sentence: ");
        string str = Console.ReadLine();

        Console.Write("Enter the word to replace: ");
        string oldWord = Console.ReadLine();

        Console.Write("Enter the new word: ");
        string newWord = Console.ReadLine();

        string result = str.Replace(oldWord, newWord);
        Console.WriteLine("Updated Sentence: "+result);
    }
}
