using System;
using System.Text.Json;
using System.Text.Json.Nodes;

class Program
{
    static void Main()
    {
        string json1 = @"{
            ""name"": ""Devansh"",
            ""age"": 21
        }";

        string json2 = @"{
            ""email"": ""devansh@example.com"",
            ""city"": ""Delhi""
        }";

        JsonObject obj1 = JsonNode.Parse(json1)!.AsObject();
        JsonObject obj2 = JsonNode.Parse(json2)!.AsObject();

        foreach (var item in obj2)
        {
            obj1[item.Key] = item.Value?.DeepClone();
        }

        Console.WriteLine(obj1.ToJsonString(new JsonSerializerOptions
        {
            WriteIndented = true
        }));
    }
}