using System;

class AnalyzesParagraph
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Paragraph:");
        string str = Console.ReadLine();

        bool isEmpty = true;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != ' ')
            {
                isEmpty = false;
                break;
            }
        }

        if (isEmpty)
        {
            Console.WriteLine("The paragraph is empty");
            return;
        }

        Console.WriteLine("Resultant Output: " + AnalyzingPara(str));
    }

    static string AnalyzingPara(string str)
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Count the Words");
        Console.WriteLine("2. Display the longest word");
        Console.WriteLine("3. Replace all occurrences");
        Console.Write("Enter Choice: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                return CountWords(str).ToString();

            case 2:
                return LongestWord(str);

            case 3:
                Console.Write("Enter Old Word: ");
                string oldWord = Console.ReadLine();

                Console.Write("Enter New Word: ");
                string newWord = Console.ReadLine();

                return ReplaceWord(str, oldWord, newWord);

            default:
                return "Invalid choice";
        }
    }

    static int CountWords(string str)
    {
        int count = 0;
        bool isWord = false;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != ' ' && !isWord)
            {
                count++;
                isWord = true;
            }
            else if (str[i] == ' ')
            {
                isWord = false;
            }
        }
        return count;
    }

    static string LongestWord(string str)
    {
        int maxLen = 0, currLen = 0, endIdx = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != ' ')
            {
                currLen++;
                if (currLen > maxLen)
                {
                    maxLen = currLen;
                    endIdx = i;
                }
            }
            else
            {
                currLen = 0;
            }
        }

        string longest = "";
        for (int i = endIdx - maxLen + 1; i <= endIdx; i++)
        {
            longest += str[i];
        }
        return longest;
    }

    static string ReplaceWord(string str, string oldWord, string newWord)
    {
        string result = "";
        string word = "";

        for (int i = 0; i <= str.Length; i++)
        {
            if (i < str.Length && str[i] != ' ')
            {
                word += str[i];
            }
            else
            {
                if (word == oldWord)
                    result += newWord;
                else
                    result += word;

                if (i < str.Length)
                    result += " ";

                word = "";
            }
        }
        return result;
    }
}
