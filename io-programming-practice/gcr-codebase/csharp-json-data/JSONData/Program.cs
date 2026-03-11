using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        string json = @"[
            { ""Name"": ""Amit"", ""Age"": 30 },
            { ""Name"": ""Priya"", ""Age"": 22 },
            { ""Name"": ""Rahul"", ""Age"": 28 },
            { ""Name"": ""Neha"", ""Age"": 24 }
        ]";

        // Convert JSON → List<Person>
        List<Person>? people = JsonSerializer.Deserialize<List<Person>>(json);

        // Filter Age > 25
        var filtered = people?.Where(p => p.Age > 25).ToList();

        // Print result
        string resultJson = JsonSerializer.Serialize(filtered, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        Console.WriteLine(resultJson);
    }
}