using System;
using System.Text;
class ConcatenateString
{
    static void Main(string[] args)
    {
        String[] word = {"Hello ","Devansh","."," Welcome ","to ","C#."};

        StringBuilder sb = new StringBuilder();

        for(int i = 0; i < word.Length; i++)
        {
            sb.Append(word[i]);
        }

        Console.WriteLine("Concatenate The String: "+sb.ToString());
    }
}