using System;
using System.Reflection;

class Configuration
{
    private static string API_KEY = "OLD_KEY";

    public static void PrintKey()
    {
        Console.WriteLine("API_KEY = " + API_KEY);
    }
}

class AccessModifyStaticFields
{
    static void Main(string[] args)
    {
        // Before modification
        Configuration.PrintKey();

        // Get type of Configuration class
        Type type = typeof(Configuration);

        // Access private static field using Reflection
        FieldInfo field = type.GetField(
            "API_KEY",
            BindingFlags.Static | BindingFlags.NonPublic
        );

        // Modify the static field (null because it's static)
        field.SetValue(null, "NEW_SECRET_KEY");

        // After modification
        Configuration.PrintKey();
    }
}
