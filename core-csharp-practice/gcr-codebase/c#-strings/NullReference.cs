using System;
class NullReference
{
    static void Main(string[] args)
    {
        DemoNullReference();
    }

    static void DemoNullReference()
    {
        try
        {
            string str = null;
            int length = str.Length;

            Console.WriteLine("Length:"+length);
        }
        catch(NullReferenceException ex)
        {
            Console.WriteLine("NullReferenceException caught");
            Console.WriteLine("Error Message: "+ex.Message);
        }
    }
}