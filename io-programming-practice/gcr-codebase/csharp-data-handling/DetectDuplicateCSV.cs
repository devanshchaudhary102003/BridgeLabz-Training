using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class DetectDuplicateCSV
{
    static void Main(string[] args)
    {
        string filePath = "data1.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        // Skip header
        var records = lines.Skip(1)
                           .Select(line => line.Split(','))
                           .ToList();

        // Group by ID (column 0) and find duplicates
        var duplicates = records
            .GroupBy(r => r[0])
            .Where(g => g.Count() > 1)
            .SelectMany(g => g);

        Console.WriteLine("Duplicate Records:");

        foreach (var record in duplicates)
        {
            Console.WriteLine(string.Join(", ", record));
        }
    }
}
