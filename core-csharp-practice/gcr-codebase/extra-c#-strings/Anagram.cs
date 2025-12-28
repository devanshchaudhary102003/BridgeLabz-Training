using System;
class Anagram
{
    static void Main(string[] args)
    {
        Console.Write("Enter first string: ");
        string s1 = Console.ReadLine().ToLower();

        Console.Write("Enter second string: ");
        string s2 = Console.ReadLine().ToLower();

        if(s1.Length != s2.Length)
        {
            Console.WriteLine("Not Anagrams");
        }

        char[] a1 = s1.ToCharArray();
        char[] a2 = s2.ToCharArray();

        Array.Sort(a1);
        Array.Sort(a2);

        if(new string(a1) == new string(a2))
        {
            Console.WriteLine("Strings are Anagrams");
        }
        else
        {
            Console.WriteLine("Strings are Not Anagrams");
        }
    }
}