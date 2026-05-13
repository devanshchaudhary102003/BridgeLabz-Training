using System;
using System.Reflection;

class ClassInformation
{
    static void Main(string[] args)
    {
        Console.Write("Enter full class name (example: System.String): ");
        string className = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(className))
        {
            Console.WriteLine("Class name cannot be empty.");
            return;
        }

        // Try to get the type directly (works for mscorlib/System.Private.CoreLib types, etc.)
        Type type = Type.GetType(className);

        // If not found, try searching all loaded assemblies
        if (type == null)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly asm in assemblies)
            {
                type = asm.GetType(className);
                if (type != null) break;
            }
        }

        if (type == null)
        {
            Console.WriteLine("Type not found. Make sure you entered the FULL name (Namespace.ClassName).");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Class: " + type.FullName);
        Console.WriteLine("--------------------------------------------------");

        BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;

        // Constructors
        Console.WriteLine("\nConstructors:");
        ConstructorInfo[] constructors = type.GetConstructors(flags);
        if (constructors.Length == 0)
        {
            Console.WriteLine("  (none)");
        }
        else
        {
            for (int i = 0; i < constructors.Length; i++)
            {
                Console.WriteLine("  " + constructors[i]);
            }
        }

        // Fields
        Console.WriteLine("\nFields:");
        FieldInfo[] fields = type.GetFields(flags);
        if (fields.Length == 0)
        {
            Console.WriteLine("  (none)");
        }
        else
        {
            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo f = fields[i];
                Console.WriteLine("  " + f.FieldType.Name + " " + f.Name);
            }
        }

        // Methods
        Console.WriteLine("\nMethods:");
        MethodInfo[] methods = type.GetMethods(flags);
        if (methods.Length == 0)
        {
            Console.WriteLine("  (none)");
        }
        else
        {
            for (int i = 0; i < methods.Length; i++)
            {
                MethodInfo m = methods[i];
                Console.WriteLine("  " + m.ReturnType.Name + " " + m.Name);
            }
        }
    }
}
