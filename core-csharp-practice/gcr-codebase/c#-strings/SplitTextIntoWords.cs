using System;
class SplitTextIntoWords
{
    static void Main(string[] args)
    {
        string str = "C Sharp is High Level Language";

        string[,] data = SplitWordsAndLengths(str);

        for(int i = 0; i < data.GetLength(0); i++)
        {
            Console.WriteLine(data[i,0] +"\t\t"+ data[i,1]);
        }
    }

    static int GetLength(string str)
    {
        int count = 0;
        foreach(char c in str)
        {
            count++;
        }
        return count;
    }

    //2D string
    static string[,] SplitWordsAndLengths(string str)
    {
        string[] words = new string[20];
        int wordCount = 0;
        string currentWord = "";

        foreach(char c in str)
        {
            if(c != ' ')
            {
                currentWord += c;
            }
            else if(currentWord != "")
            {
                words[wordCount++] = currentWord;
                currentWord = "";
            }
        }

        if(currentWord != "")
        {
            words[wordCount++] = currentWord;
        }

        string[,] result = new string[wordCount,2];

        for(int i = 0; i < wordCount; i++)
        {
            result[i,0] = words[i];
            result[i,1] = GetLength(words[i]).ToString();
        }
        return result;
    }
}