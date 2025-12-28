using System;
class IndexOutOfRangeArray
{
    static void Main(string[] args)
    {
        try
        {
            int[] arr = {10,20,30,40,50};

            Console.WriteLine(arr[6]);
        }
        catch(IndexOutOfRangeException ex)
        {
            Console.WriteLine("IndexOutOfRangeException caught");
            Console.WriteLine("Error Message:"+ex.Message);
        }
    }
}