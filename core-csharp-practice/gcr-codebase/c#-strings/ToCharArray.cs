using System;
class ToCharArray
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a String:");
        string str = Console.ReadLine();

        char[] customChars = GetCharWithoutToCharArray(str);
        char[] builtInChars = str.ToCharArray();

        Console.WriteLine("Character using custom method:");
        DisplayChar(customChars);

        Console.WriteLine("Character using Built In method:");
        DisplayChar(builtInChars);
    }
    static char[] GetCharWithoutToCharArray(string str)
    {
        char[] result = new char[str.Length];

        for(int i = 0; i < str.Length; i++)
        {
            result[i] = str[i];
        }
        return result;
    }

    static void DisplayChar(char[] c)
    {
        for(int i = 0; i < c.Length; i++)
        {
            Console.WriteLine(c[i]);
        }
    }
}