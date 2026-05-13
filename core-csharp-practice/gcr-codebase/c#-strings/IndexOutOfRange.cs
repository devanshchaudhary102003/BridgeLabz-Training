using System;
class IndexOutOfRange{
    static void Main(string[] args)
    {
        DemoIndexOutOfRange();
    }
    static void DemoIndexOutOfRange()
    {
        try
        {
            string str = "Devansh";

            char ch = str[10];
            Console.WriteLine(ch);
            
        }
        catch(IndexOutOfRangeException ex)
        {
            Console.WriteLine("IndexOutOfRangeException caught");
            Console.WriteLine("Error Message:"+ex.Message);
        }
    }
}