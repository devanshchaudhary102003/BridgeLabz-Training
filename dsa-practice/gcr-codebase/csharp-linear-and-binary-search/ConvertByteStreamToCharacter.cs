using System;
using System.IO;
class ConvertByteStreamToCharacter
{
    static void Main(string[] args)
    {
        string filePath = "sample.txt";

        // Step 1: Create a byte stream (FileStream)
        FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        // Step 2: Convert byte stream to character stream using StreamReader
        StreamReader reader = new StreamReader(fileStream);

        // Step 3: Read and print characters
        int ch;
        while ((ch = reader.Read()) != -1)
        {
            Console.Write((char)ch);
        }

        // Step 4: Close streams
        reader.Close();
        fileStream.Close();
    }
}