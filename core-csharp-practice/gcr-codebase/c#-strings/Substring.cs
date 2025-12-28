using System;
class Substring
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a String:");
        string str = Console.ReadLine();

        Console.WriteLine("Enter start index:");
        int StartIdx = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter end index:");
        int EndIdx = Convert.ToInt32(Console.ReadLine());

        string result = CreateSubstring(str,StartIdx,EndIdx);
        string builtinresult = str.Substring(StartIdx,EndIdx - StartIdx);

        Console.WriteLine("result without builtin:"+result);
        Console.WriteLine("result with builtin:"+builtinresult);

        Console.WriteLine("Both are Equals?:"+(result.Equals(builtinresult)? "Yes":"No"));

    }
    static string CreateSubstring(String str,int s,int e)
    {
        string result = "";
        for(int i = s; i < e; i++)
        {
            result += str[i];
        }
        return result;
    }
}