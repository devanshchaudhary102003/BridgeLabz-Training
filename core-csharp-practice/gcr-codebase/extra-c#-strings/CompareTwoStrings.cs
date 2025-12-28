using System;
class CompareTwoStrings
{
    static void Main(string[] args)
    {
        string s1 = "apple";
        string s2 = "banana";

        int minLength = Math.Min(s1.Length,s2.Length);
        bool isDifferent = false;

        for(int i = 0; i < minLength; i++)
        {
            if(s1[i] < s2[i])
            {
                Console.WriteLine(s1+" comes before "+s2+" in lexicographical order");
                isDifferent = true;
                break;
            }
            else if(s1[i] > s2[i])
            {
                Console.WriteLine(s2+" comes before "+s1+" in lexicographical order");
                isDifferent = true;
                break;
            }
        }
        if (!isDifferent)
        {
            if(s1.Length < s2.Length)
            {
                Console.WriteLine(s1+" comes before "+s2+" in lexicographical order");
            }
            else if(s1.Length > s2.Length)
            {
                Console.WriteLine(s2+" comes before "+s1+" in lexicographical order");
            }
            else
            {
                Console.WriteLine("Both strings are equals");
            }
        }
    }
}