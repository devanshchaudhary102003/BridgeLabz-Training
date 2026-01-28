using System;
using System.Text.RegularExpressions;

class ValidateUsername
{
    static void Main(string[] args)
    {
        string pattern = @"^[A-Za-z][A-Za-z0-9_]{4,14}$";

        string[] usernames = {"user_2003", "211user","dev","USER_NAME_02"};

        foreach(string username in usernames)
        {
            if(Regex.IsMatch(username, pattern))
                Console.WriteLine(username+"-> Valid");

            else    
                Console.WriteLine(username+"-> Invalid");
        }
    }
}