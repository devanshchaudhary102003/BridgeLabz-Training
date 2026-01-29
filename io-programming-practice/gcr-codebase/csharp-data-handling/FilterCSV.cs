using System;
using System.IO;

class FilterCSV
{
    static void Main(string[] args)
    {
        string filePath = "studentss.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("CSV file not found");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        Console.WriteLine("Students scoring more than 80:\n");

        for(int i = 1; i < lines.Length; i++)
        {
            string[] data = lines[i].Split(',');

            int marks = int.Parse(data[3]);

            if(marks > 80)
            {
                Console.WriteLine("ID: "+data[0]+", Name: "+data[1]+", Age: "+data[2]+", Marks: "+data[3]);
            }
        }
    }
}