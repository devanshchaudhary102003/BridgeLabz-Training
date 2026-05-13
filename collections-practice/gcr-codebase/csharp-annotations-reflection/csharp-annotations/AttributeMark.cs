using System;
using System.Linq;
using System.Reflection;

// 1) Create the attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class ImportantMethodAttribute : Attribute
{
    public string Level { get; }

    // Optional parameter with default value
    public ImportantMethodAttribute(string level = "HIGH")
    {
        Level = level;
    }
}

// 2) Apply the attribute to methods
public class DemoService
{
    [ImportantMethod] // default level = HIGH
    public void BackupDatabase()
    {
        Console.WriteLine("Backing up database...");
    }

    [ImportantMethod("MEDIUM")]
    public void ClearCache()
    {
        Console.WriteLine("Clearing cache...");
    }

    public void NormalMethod()
    {
        Console.WriteLine("Normal method");
    }
}

class AttributeMark
{
    static void Main(string[] args)
    {
        Type type = typeof(DemoService);

        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
        );

        Console.WriteLine("Important methods in class: " + type.Name);
        Console.WriteLine("----------------------------------");

        int count = 0;

        foreach (MethodInfo method in methods)
        {
            ImportantMethodAttribute attr =
                method.GetCustomAttribute<ImportantMethodAttribute>();

            if (attr != null)
            {
                Console.WriteLine(
                    "Method: " + method.Name +
                    " | Level: " + attr.Level
                );
                count++;
            }
        }

        Console.WriteLine("----------------------------------");
        Console.WriteLine("Total Important Methods: " + count);
    }
}
