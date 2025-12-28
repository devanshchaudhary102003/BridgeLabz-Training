using System;
class ArgumentOutOfRange
{
    static void Main(string[] args)
    {
        try
        {
            string str = "Hello World";

            string result = str.Substring(20);
            Console.WriteLine(result);
            
        }
        catch(ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("ArgumentOutOfRangeException caught");
            Console.WriteLine("Error Message:"+ex.Message);
        }
    }
}