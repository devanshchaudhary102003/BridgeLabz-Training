using System;
using System.Collections.Generic;
using System.Text.Json;

public class Student
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Devansh", Age = 21 },
            new Student { Name = "Rahul", Age = 22 },
            new Student { Name = "Priya", Age = 20 }
        };

        string json = JsonSerializer.Serialize(students, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        Console.WriteLine(json);
    }
}