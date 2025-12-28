using System;
class PalindromeChecker
{
    static void Main(string[] args)
    {
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();

        if (IsPalindrome(str))
        {
            Console.WriteLine("Palindrome");
        }
        else
        {
            Console.WriteLine("Not a Palindrome");
        }
    }
    static bool IsPalindrome(string str)
    {
        string clean = str.Replace(" ","").ToLower();

        int left = 0;
        int right = clean.Length - 1;

        while(left < right)
        {
            if(clean[left] != clean[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
}