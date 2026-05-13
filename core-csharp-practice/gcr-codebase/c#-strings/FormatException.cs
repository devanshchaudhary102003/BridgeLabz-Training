using System;
class FormatException
{
    static void Main(string[] args)
    {
        try
        {
            string str = "ABC";

            int number = int.Parse(str);

            Console.WriteLine("Number:"+number);
        }
        catch(System.FormatException ex)
        {
            Console.WriteLine("FormatException caught");
            Console.WriteLine("Error Message:"+ex.Message);
        }
    }
}