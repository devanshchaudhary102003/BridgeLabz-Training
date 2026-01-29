using System;
using System.Linq;
using System.Reflection;

// 1) Custom attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class ImportantMethodAttribute : Attribute
{
    public string Level { get; }

    // Optional parameter with default "HIGH"
    public ImportantMethodAttribute(string level = "HIGH")
    {
        Level = level;
    }
}

// 2) Example class with annotated methods
public class DemoService
{
    [ImportantMethod] // uses default "HIGH"
    public void ProcessPayment()
    {
        Console.WriteLine("Processing payment...");
    }

    [ImportantMethod("MEDIUM")]
    public void GenerateReport()
    {
        Console.WriteLine("Generating report...");
    }

    public void NormalMethod()
    {
        Console.WriteLine("I am not marked important.");
    }
}

class TodoAttribute
{
    static void Main(string[] args)
    {
        Type t = typeof(DemoService);

        // 3) Retrieve annotated methods using Reflection
        var importantMethods = t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Select(m => new
            {
                Method = m,
                Attr = m.GetCustomAttribute<ImportantMethodAttribute>(inherit: true)
            })
            .Where(x => x.Attr != null)
            .ToList();

        Console.WriteLine("Important methods found in: " + t.Name);
        Console.WriteLine("-----------------------------------");

        foreach (var item in importantMethods)
        {
            Console.WriteLine($"Method: {item.Method.Name}, Level: {item.Attr.Level}");
        }

        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Total Important Methods: " + importantMethods.Count);
    }
}
