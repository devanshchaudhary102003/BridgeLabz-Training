using System;
using System.Diagnostics;
using System.Text;
class SentenceFormatter
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Paragraph:");
        string str = Console.ReadLine();

        Console.WriteLine("Formatted String:"+SentenceFormatting(str));
    }

    static string SentenceFormatting(string str)
    {
        string ans = Punctuation(str);
        ans = CapitalLetter(ans);
        ans = Trimmered(ans);
        return ans;
    }
    static string Punctuation(string str)
    {
        string result = "";
        for(int i = 0; i < str.Length; i++)
        {
            if(str[i] == '.' || str[i] == ',' || str[i] == '?' || str[i] == '!' || str[i] == ':')
            {
                result += str[i] + " ";
            }
            else
            {
                result += str[i];
            }
        }
        return result;
    }
    static string CapitalLetter(string str)
    {
        char[] arr = str.ToCharArray();
        if(arr[0] >= 'a' && arr[0] <= 'z')
        {
            arr[0] = (char)(arr[0] - 32);
        }
        for(int i = 0; i < arr.Length; i++)
        {
            if(arr[i] == '.' || arr[i] == '?' || arr[i] == '!' && str[i+2] > str.Length)
            {
                int j = i+1;
                while(j < arr.Length && arr[j] == ' ')
                {
                    j++;
                }
                if(j < arr.Length && arr[j] >= 'a' && arr[j] <= 'z')
                {
                    arr[j] = (char)(arr[j] - 32);
                }
            }
        }
        return new string(arr);
    }
    static string Trimmered(string str)
    {
        string result = "";
        bool spaceFound = false;

        for(int i = 0; i < str.Length; i++)
        {
            if(str[i] == ' ')
            {
                if (!spaceFound)
                {
                    result += ' ';
                    spaceFound = true;
                }
            }
            else
            {
                result += str[i];
                spaceFound = false;   
            }
        }
        return result;
    }
}