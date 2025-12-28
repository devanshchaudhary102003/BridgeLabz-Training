using System;
class LowerCase
{
    static void Main(string[] args)
    {
        string str = "Hello World";
        
        string asciiLower = ToLowerAscii(str);
        string builtInLower = str.ToLower();

        Console.WriteLine("Original Text   : " +str);
        Console.WriteLine("ASCII Lowercase : " +asciiLower);
        Console.WriteLine("Built-in Lower  : " +builtInLower);
    }

    static string ToLowerAscii(string str)
    {
        char[] result = str.ToCharArray();

        for(int i = 0; i < result.Length; i++)
        {
            if(result[i] >= 'A' && result[i] <= 'Z')
            {
                result[i] = (char)(result[i] + 32);
            }
        }
        return new string(result);
    }
}