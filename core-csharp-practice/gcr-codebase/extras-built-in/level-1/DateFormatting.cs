using System;

class DateFormatting
{
    static void Main()
    {
        DateTime today = DateTime.Now;

        Console.WriteLine("dd/MM/yyyy  : " + today.ToString("dd/MM/yyyy"));
        Console.WriteLine("yyyy-MM-dd  : " + today.ToString("yyyy-MM-dd"));
        Console.WriteLine("EEE, MMM dd, yyyy : " + today.ToString("ddd, MMM dd, yyyy"));
    }
}
