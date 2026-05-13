using System;
using System.IO;

class FileRead
{
    static void Main(string[] args)
    {
        try
        {
            // Attempt to read the file
            string content = File.ReadAllText("data.txt");
            Console.WriteLine("File Contents:");
            Console.WriteLine(content);
        }
        catch (IOException)
        {
            // Handles file not found and other IO-related errors
            Console.WriteLine("File not found");
        }
    }
}
