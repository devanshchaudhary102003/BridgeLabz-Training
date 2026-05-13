using System;
class CompareTwoStrings
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a String1:");
        string str1 = Console.ReadLine();

        Console.WriteLine("Enter a String2:");
        string str2 = Console.ReadLine();

        bool result = IsCompare(str1,str2);
        bool builtinresult = str1.Equals(str2);

        Console.WriteLine("Compare result : "+result);
        Console.WriteLine("Compare Built-in result:"+builtinresult);

    }
    static bool IsCompare(string str1, string str2)
    {
        if(str1.Length != str2.Length)
        {
            return false;
        }

        for(int i = 0; i < str1.Length; i++)
        {
            if(str1[i] != str2[i])
            {
                return false;
            }
        }
        return true;
    }
}