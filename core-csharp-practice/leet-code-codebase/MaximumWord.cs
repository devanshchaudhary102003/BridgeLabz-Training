using System;

class MaximumWord
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of sentences: ");
        int n = int.Parse(Console.ReadLine());

        string[] sentences = new string[n];

        Console.WriteLine("Enter the sentences:");
        for (int i = 0; i < n; i++)
        {
            sentences[i] = Console.ReadLine();
        }

        int result = MostWordsFound(sentences);
        Console.WriteLine("Maximum number of words in a sentence: " + result);
    }

    public static int MostWordsFound(string[] sentences)
    {
        int count = 1;
        int max = 0;

        for (int i = 0; i < sentences.Length; i++)
        {
            count = 1;
            for (int j = 0; j < sentences[i].Length; j++)
            {
                if (sentences[i][j] == ' ')
                {
                    count++;
                }
            }
            max = Math.Max(max, count);
        }
        return max;
    }
}
