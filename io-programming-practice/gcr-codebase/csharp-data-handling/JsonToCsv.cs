using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

public class Student
{
    public int Id;
    public string Name;
    public int Age;
    public int Marks;
}

class JsonToCsv
{
    static void Main(string[] args)
    {
        string jsonFile = "students.json";
        string csvFile = "students.csv";
        string jsonFromCsvFile = "students_from_csv.json";

        EnsureSampleJson(jsonFile);

        List<Student> students = ReadFromJson(jsonFile);
        WriteToCsv(csvFile, students);
        Console.WriteLine("JSON → CSV done");

        List<Student> fromCsv = ReadFromCsv(csvFile);
        WriteToJson(jsonFromCsvFile, fromCsv);
        Console.WriteLine("CSV → JSON done");
    }

    // -------- JSON --------
    static List<Student> ReadFromJson(string path)
    {
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<Student>>(json);
    }

    static void WriteToJson(string path, List<Student> students)
    {
        string json = JsonConvert.SerializeObject(students, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    // -------- CSV --------
    static void WriteToCsv(string path, List<Student> students)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Id,Name,Age,Marks");

        foreach (Student s in students)
        {
            sb.AppendLine(
                s.Id + "," +
                s.Name + "," +
                s.Age + "," +
                s.Marks
            );
        }

        File.WriteAllText(path, sb.ToString());
    }

    static List<Student> ReadFromCsv(string path)
    {
        List<Student> list = new List<Student>();
        string[] lines = File.ReadAllLines(path);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split(',');

            Student s = new Student();
            s.Id = int.Parse(cols[0]);
            s.Name = cols[1];
            s.Age = int.Parse(cols[2]);
            s.Marks = int.Parse(cols[3]);

            list.Add(s);
        }

        return list;
    }

    static void EnsureSampleJson(string path)
    {
        if (File.Exists(path)) return;

        List<Student> sample = new List<Student>
        {
            new Student { Id = 1, Name = "Aarav", Age = 20, Marks = 85 },
            new Student { Id = 2, Name = "Diya", Age = 19, Marks = 92 }
        };

        WriteToJson(path, sample);
    }
}
