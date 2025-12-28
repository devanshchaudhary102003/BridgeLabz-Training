using System;
class UpperCase
{
    static void Main(string[] args)
    {
        string str = "Hello World";
        
        string asciiUpper = ToUpperAscii(str);
        string builtInUpper = str.ToUpper();

        Console.WriteLine("Original Text   : " +str);
        Console.WriteLine("ASCII Uppercase : " +asciiUpper);
        Console.WriteLine("Built-in Upper  : " +builtInUpper);
    }

    static string ToUpperAscii(string str)
    {
        char[] result = str.ToCharArray();

        for(int i = 0; i < result.Length; i++)
        {
            if(result[i] >= 'a' && result[i] <= 'z')
            {
                result[i] = (char)(result[i] - 32);
            }
        }
        return new string(result);
    }
}