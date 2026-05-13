using System;
using System.Collections.Generic;
using System.IO;

class MergeCsvFiles
{
    static void Main(string[] args)
    {
        string file1 = "students1.csv";
        string file2 = "students2.csv";
        string outputFile = "merged_students.csv";

        Dictionary<string, string[]> students1 = new Dictionary<string, string[]>();
        Dictionary<string, string[]> students2 = new Dictionary<string, string[]>();

        // Read students1.csv
        string[] lines1 = File.ReadAllLines(file1);
        for (int i = 1; i < lines1.Length; i++)
        {
            string[] data = lines1[i].Split(',');
            students1[data[0]] = data; // ID as key
        }

        // Read students2.csv
        string[] lines2 = File.ReadAllLines(file2);
        for (int i = 1; i < lines2.Length; i++)
        {
            string[] data = lines2[i].Split(',');
            students2[data[0]] = data; // ID as key
        }

        // Write merged CSV
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            writer.WriteLine("ID,Name,Age,Marks,Grade");

            foreach (var id in students1.Keys)
            {
                if (students2.ContainsKey(id))
                {
                    string[] s1 = students1[id];
                    string[] s2 = students2[id];

                    writer.WriteLine(
                        s1[0] + "," +  // ID
                        s1[1] + "," +  // Name
                        s1[2] + "," +  // Age
                        s2[1] + "," +  // Marks
                        s2[2]           // Grade
                    );
                }
            }
        }

        Console.WriteLine("CSV files merged successfully!");
    }
}
