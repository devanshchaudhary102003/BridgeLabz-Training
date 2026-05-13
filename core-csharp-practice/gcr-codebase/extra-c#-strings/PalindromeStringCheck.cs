using System;
class PalindromeStringCheck
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a String:");
        string str = Console.ReadLine();

        int left = 0;
        int right = str.Length - 1; 
        bool IsPalindrome = true;

        while(left < right)
        {
            if(str[left] != str[right])
            {
                IsPalindrome = false;
                break;
            }
            left++;
            right--;
        }

        if (IsPalindrome)
        {
            Console.WriteLine("The string is a Palindrome");
        }
        else
        {
            Console.WriteLine("The string is not a Palindrome");
        }
    }
}