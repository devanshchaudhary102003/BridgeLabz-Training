using System;
using System.IO;

class StudentBinaryData
{
    static void Main(string[] args)
    {
        string filePath = "student.dat";

        try
        {
            // ----------- INPUT FROM USER -----------
            Console.Write("Enter Roll Number: ");
            int rollNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter GPA: ");
            double gpa = Convert.ToDouble(Console.ReadLine());

            // ----------- WRITE DATA (BinaryWriter) -----------
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(rollNo);
                writer.Write(name);
                writer.Write(gpa);
            }

            Console.WriteLine("\nStudent data saved to binary file.");

            // ----------- READ DATA (BinaryReader) -----------
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                int r = reader.ReadInt32();
                string n = reader.ReadString();
                double g = reader.ReadDouble();

                Console.WriteLine("\nStudent data retrieved from file:");
                Console.WriteLine("Roll Number: " + r);
                Console.WriteLine("Name: " + n);
                Console.WriteLine("GPA: " + g);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("File I/O Error: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }
}
