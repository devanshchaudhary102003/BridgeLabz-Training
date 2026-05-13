using System;
class SubstringOccurrences
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a main String:");
        string main = Console.ReadLine();

        Console.WriteLine("Enter a  subString:");
        string sub = Console.ReadLine();

        int count = 0;

        for(int i = 0;i <= main.Length - sub.Length; i++)
        {
            if(main.Substring(i,sub.Length) == sub)
            {
                count++;
            }
        }
        Console.WriteLine("substring occurs in a string: "+count);
    }
}