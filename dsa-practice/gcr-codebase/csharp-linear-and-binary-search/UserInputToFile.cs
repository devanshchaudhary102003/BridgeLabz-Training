using System;
using System.IO;

class UserInputToFile
{
    static void Main(string[] args)
    {
        string filePath = "userinput.txt";

        // Step 1: Create StreamWriter to write characters to file
        StreamWriter writer = new StreamWriter(filePath);

        Console.WriteLine("Enter text (type 'exit' to stop):");

        // Step 2: Read input from user
        while (true)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
                break;

            writer.WriteLine(input); // write input to file
        }

        // Step 3: Close writer
        writer.Close();

        Console.WriteLine("Data written to file successfully!");
    }
}
