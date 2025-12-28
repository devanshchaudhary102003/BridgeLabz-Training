using System;
class ToggleCaseOfCharacters
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a String:");
        string str = Console.ReadLine();

        char[] ch = new char[str.Length];

        for(int i = 0; i < str.Length; i++)
        {
            if (char.IsUpper(str[i]))
            {
                ch[i] = char.ToLower(str[i]);
            }
            else if (char.IsLower(str[i]))
            {
                ch[i] = char.ToUpper(str[i]);
            }
            else
            {
                ch[i] = str[i];
            }
        }
        Console.WriteLine("Toggle Case of Characters:"+new string(ch));
    }
}