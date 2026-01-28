using System;
using System.Text.RegularExpressions;
class ValidateHexColorCode
{
    static void Main(string[] args)
    {
        string[] inputs = { "#FFA500", "#ff4500", "#123", "FFA500", "#12FG00" };

        string pattern = "#[0-9A-Fa-f]{6}$";

        for(int i = 0; i < inputs.Length; i++)
        {
            string s = inputs[i];

            if(Regex.IsMatch(s,pattern))
                Console.WriteLine(s+"-> Valid");

            else    
                Console.WriteLine(s+"-> Invalid");
        }
    }
}
