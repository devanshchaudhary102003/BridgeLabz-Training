using System;
using System.IO;

class ReadFirstLine
{
    static void Main(string[] args)
    {
        try
        {
            // using ensures the file is closed automatically
            using (StreamReader reader = new StreamReader("info.txt"))
            {
                string firstLine = reader.ReadLine();
                Console.WriteLine(firstLine);
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Error reading file");
        }
    }
}
