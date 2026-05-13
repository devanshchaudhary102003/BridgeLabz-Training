using System;
using System.IO;

class UserInputToFile
{
    static void Main()
    {
        string filePath = "UserDetails.txt";

        // StreamReader for console input
        StreamReader reader = new StreamReader(Console.OpenStandardInput());
        StreamWriter writer = null;

        try
        {
            Console.WriteLine("Enter your name:");
            string name = reader.ReadLine();

            Console.WriteLine("Enter your age:");
            string age = reader.ReadLine();

            Console.WriteLine("Enter your favorite programming language:");
            string language = reader.ReadLine();

            // StreamWriter for file writing
            writer = new StreamWriter(filePath, true); // true = append mode

            writer.WriteLine("Name: " + name);
            writer.WriteLine("Age: " + age);
            writer.WriteLine("Favorite Language: " + language);
            writer.WriteLine("--------------------------");

            Console.WriteLine("User information saved successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("File I/O error occurred:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error:");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (writer != null)
            {
                writer.Close();
            }
            reader.Close();
        }
    }
}
