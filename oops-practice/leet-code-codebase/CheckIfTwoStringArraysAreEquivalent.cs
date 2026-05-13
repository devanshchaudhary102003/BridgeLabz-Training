using System;

class CheckIfTwoStringArraysAreEquivalent
{
    public static bool ArrayStringsAreEqual(string[] word1, string[] word2)
    {
        string s1 = "";
        string s2 = "";

        for (int i = 0; i < word1.Length; i++)
        {
            s1 += word1[i];
        }

        for (int i = 0; i < word2.Length; i++)
        {
            s2 += word2[i];
        }

        return s1 == s2;
    }

    static void Main()
    {
        // Input for word1
        Console.Write("Enter size of word1: ");
        int n1 = int.Parse(Console.ReadLine());

        string[] word1 = new string[n1];
        Console.WriteLine("Enter elements of word1:");
        for (int i = 0; i < n1; i++)
        {
            word1[i] = Console.ReadLine();
        }

        // Input for word2
        Console.Write("Enter size of word2: ");
        int n2 = int.Parse(Console.ReadLine());

        string[] word2 = new string[n2];
        Console.WriteLine("Enter elements of word2:");
        for (int i = 0; i < n2; i++)
        {
            word2[i] = Console.ReadLine();
        }

        // Function call
        bool result = ArrayStringsAreEqual(word1, word2);

        Console.WriteLine("Output: " + result);
        Console.ReadLine();
    }
}
