/*📌 Problem Statement: Write a C# program that reads the contents of a text file and writes it into a new file. If the source file does not exist, display an appropriate message. 
Requirements: Use FileStream for reading and writing. Handle IOException properly. Ensure that the destination file is created if it does not exist.*/
using System;
using System.IO;
using System.Text;
class ReadWrite
{
    static void Main(string[] args)
    {
        string sourcePath = "source.txt";
        string destinationPath = "destination.txt";

        try
        {
            // Check if source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source File Does Not Exist.");
                return;
            }

            // Open source file for reading
            using(FileStream readStream = new FileStream(
                sourcePath, FileMode.Open, FileAccess.Read
            ))
            {
                // Open/Create destination file for writing
                using(FileStream writeStream = new FileStream(
                    destinationPath, FileMode.Create, FileAccess.Write
                ))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    // Read and write byte by byte (in chunks)
                    while((bytesRead = readStream.Read(buffer,0,buffer.Length)) > 0)
                    {
                        writeStream.Write(buffer,0,bytesRead);
                    }
                }
            }
            Console.WriteLine("File copied successfully.");
        }
        catch(IOException ex)
        {
            Console.WriteLine("File error occurred:");
            Console.WriteLine(ex.Message);
        }

        catch(Exception ex)
        {
            Console.WriteLine("Unexpected error:");
            Console.WriteLine(ex.Message);
        }
    }
}