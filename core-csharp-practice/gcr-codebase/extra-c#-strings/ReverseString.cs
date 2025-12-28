using System;
class ReverseString
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a String:");
        string str = Console.ReadLine();

        for(int i = str.Length-1; i >= 0; i--)
        {
            Console.Write(str[i]);
        }
    }
}