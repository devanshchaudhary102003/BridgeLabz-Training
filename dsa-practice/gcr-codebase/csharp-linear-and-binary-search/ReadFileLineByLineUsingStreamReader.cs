using System;
using System.IO;
using Microsoft.Win32.SafeHandles;
class ReadFileLineByLineUsingStreamReader
{
    static void Main(string[] args)
    {
        string filePath = "sample.txt"; 

        //Check if the file exists
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File Not Found: "+filePath);
            return;
        }

        //Using StreamReader to read the file line by line
        try
        {
            using(StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("An error occurred while reading the file: ");
            Console.WriteLine(e.Message);
        }
    }
}