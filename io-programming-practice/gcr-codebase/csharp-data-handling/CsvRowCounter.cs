using System;
using System.IO;

class CsvRowCounter
{
    static void Main(string[] args)
    {
        string filePath = "student.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("CSV File Not Found.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        int recordCount = lines.Length - 1;

        if(recordCount < 0)
        {
            recordCount = 0;
        }
        Console.WriteLine("Number of records (excluding header): " + recordCount);
    }
}