using System;
using System.IO;
using System.Text.Json.Nodes;

class Program
{
    static void Main()
    {
        string path = "data.json";

        if (!File.Exists(path))
        {
            Console.WriteLine("File not found!");
            return;
        }

        string json = File.ReadAllText(path);

        JsonObject obj = JsonNode.Parse(json)!.AsObject();

        foreach (var item in obj)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }
    }
}