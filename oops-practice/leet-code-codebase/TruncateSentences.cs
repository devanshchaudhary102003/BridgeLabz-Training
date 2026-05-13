using System;

class TruncateSentences
{
    static void Main(string[] args)
    {
        Console.Write("Enter a sentence: ");
        string s = Console.ReadLine();

        Console.Write("Enter number of words to keep (k): ");
        int k = Convert.ToInt32(Console.ReadLine());

        string result = TruncateSentence(s, k);

        Console.WriteLine("Truncated sentence:");
        Console.WriteLine(result);
    }

    static string TruncateSentence(string s, int k)
    {
        string result = "";
        int wordCount = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                wordCount++;
                if (wordCount == k)
                    break;
            }
            result += s[i];
        }

        return result;
    }
}
