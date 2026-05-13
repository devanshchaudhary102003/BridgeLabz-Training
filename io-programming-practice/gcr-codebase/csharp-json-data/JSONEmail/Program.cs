using System;
using System.IO;
using System.Text.Json.Nodes;

class Program
{
    static void Main(string[] args)
    {
        string json = File.ReadAllText("user.json");

        JsonNode? node = JsonNode.Parse(json);

        if (node is not JsonObject obj)
        {
            Console.WriteLine("JSON is not a valid object.");
            return;
        }

        string name = obj["name"]?.GetValue<string>() ?? "Not Found";
        string email = obj["email"]?.GetValue<string>() ?? "Not Found";

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Email: {email}");
    }
}