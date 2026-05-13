using System;
using System.Text.RegularExpressions;
class ValidateLicensePlateNumber
{
    static bool IsValidPlate(string plate)
    {
        return Regex.IsMatch(plate, "^[A-Z]{2}[0-9]{4}$");
    }
    static void Main(string[] args)
    {
        string[] tests = { "AB1234","A12345","ab1221","AD23C","WQ99999"};

        foreach(string t in tests)
        {
            Console.WriteLine(t+"->"+(IsValidPlate(t) ? "Valid" : "Invalid"));
        }
    }
}