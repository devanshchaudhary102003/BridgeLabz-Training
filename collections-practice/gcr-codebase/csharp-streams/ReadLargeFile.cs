using System;
using System.IO;

class ReadLargeFile
{
    static void Main(string[] args)
    {
        string filePath = "largefile.txt";

        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    // Case-insensitive search for "error"
                    if (line.IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("File I/O Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }
}
