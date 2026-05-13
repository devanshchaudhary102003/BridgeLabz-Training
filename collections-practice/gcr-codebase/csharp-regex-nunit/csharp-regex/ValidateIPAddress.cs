using System;
using System.Text.RegularExpressions;

class ValidateIPAddress
{
    static void Main()
    {
        string[] testIPs = {"192.168.1.1","255.255.255.255","0.0.0.0","256.1.1.1","192.168.1","192.168.01.1"};

        string pattern = @"^((25[0-5]|2[0-4][0-9]|1?[0-9]{1,2})\.){3}(25[0-5]|2[0-4][0-9]|1?[0-9]{1,2})$";

        foreach (string ip in testIPs)
        {
            if (Regex.IsMatch(ip, pattern))
                Console.WriteLine(ip + " -> Valid");
            else
                Console.WriteLine(ip + " -> Invalid");
        }
    }
}
