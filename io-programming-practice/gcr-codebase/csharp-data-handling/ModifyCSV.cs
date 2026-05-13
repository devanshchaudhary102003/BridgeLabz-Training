using System;
using System.Globalization;
using System.IO;

class ModifyCSV
{
    static void Main(string[] args)
    {
        string inputFile = "employees.csv";
        string outputFile = "employees_updated.csv";

        string[] lines = File.ReadAllLines(inputFile);

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            // Write header
            writer.WriteLine(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                int id = int.Parse(data[0]);
                string name = data[1];
                string department = data[2];
                double salary = double.Parse(data[3], CultureInfo.InvariantCulture);

                if (department.Equals("IT", StringComparison.OrdinalIgnoreCase))
                {
                    salary = salary * 1.10;
                }

                writer.WriteLine(
                    id + "," +
                    name + "," +
                    department + "," +
                    salary.ToString("F2", CultureInfo.InvariantCulture)
                );
            }
        }

        Console.WriteLine("Salary update completed. Check employees_updated.csv");
    }
}
