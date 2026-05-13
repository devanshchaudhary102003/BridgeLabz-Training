using System;
using System.IO;
using System.Text;

class FilterStreamDemo
{
    static void Main(string[] args)
    {
        string sourceFile = "input.txt";
        string destinationFile = "output.txt";

        try
        {
            // Check if source file exists
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine("Source file does not exist.");
                return;
            }

            // FileStreams
            using (FileStream readFs = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            using (FileStream writeFs = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))

            // BufferedStreams for efficiency
            using (BufferedStream bufferedRead = new BufferedStream(readFs))
            using (BufferedStream bufferedWrite = new BufferedStream(writeFs))

            // StreamReader & StreamWriter with encoding
            using (StreamReader reader = new StreamReader(bufferedRead, Encoding.UTF8))
            using (StreamWriter writer = new StreamWriter(bufferedWrite, Encoding.UTF8))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    // Convert uppercase to lowercase
                    string lowerLine = line.ToLower();
                    writer.WriteLine(lowerLine);
                }
            }

            Console.WriteLine("File processed successfully.");
            Console.WriteLine("Uppercase letters converted to lowercase.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("File I/O Error: " + ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Access Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }
}
