using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Text;

public class JsonReflectionSerializer
{
    public static string ToJsonLike(object obj)
    {
        return SerializeValue(obj);
    }

    private static string SerializeValue(object value)
    {
        if (value == null)
            return "null";

        Type t = value.GetType();

        // string
        if (t == typeof(string))
            return QuoteAndEscape((string)value);

        // char
        if (t == typeof(char))
            return QuoteAndEscape(value.ToString());

        // bool
        if (t == typeof(bool))
            return ((bool)value) ? "true" : "false";

        // numeric
        if (IsNumericType(t))
            return Convert.ToString(value, CultureInfo.InvariantCulture);

        // enum
        if (t.IsEnum)
            return QuoteAndEscape(value.ToString());

        // collections (array, list, etc.)
        IEnumerable enumerable = value as IEnumerable;
        if (enumerable != null && !(value is string))
            return SerializeEnumerable(enumerable);

        // object
        return SerializeObject(value);
    }

    private static string SerializeEnumerable(IEnumerable enumerable)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[");

        bool first = true;
        foreach (object item in enumerable)
        {
            if (!first)
                sb.Append(", ");

            first = false;
            sb.Append(SerializeValue(item));
        }

        sb.Append("]");
        return sb.ToString();
    }

    private static string SerializeObject(object obj)
    {
        Type t = obj.GetType();
        StringBuilder sb = new StringBuilder();
        sb.Append("{");

        bool first = true;

        // Fields
        FieldInfo[] fields = t.GetFields(
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (FieldInfo field in fields)
        {
            if (field.Name.Contains("k__BackingField"))
                continue;

            if (!first)
                sb.Append(", ");

            first = false;
            sb.Append(QuoteAndEscape(field.Name));
            sb.Append(": ");
            sb.Append(SerializeValue(field.GetValue(obj)));
        }

        // Properties
        PropertyInfo[] props = t.GetProperties(
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (PropertyInfo prop in props)
        {
            if (prop.GetIndexParameters().Length > 0)
                continue;

            MethodInfo getter = prop.GetGetMethod(true);
            if (getter == null)
                continue;

            object value;
            try
            {
                value = prop.GetValue(obj, null);
            }
            catch
            {
                value = "unreadable";
            }

            if (!first)
                sb.Append(", ");

            first = false;
            sb.Append(QuoteAndEscape(prop.Name));
            sb.Append(": ");
            sb.Append(SerializeValue(value));
        }

        sb.Append("}");
        return sb.ToString();
    }

    private static string QuoteAndEscape(string s)
    {
        if (s == null)
            return "\"\"";

        s = s.Replace("\\", "\\\\")
             .Replace("\"", "\\\"")
             .Replace("\n", "\\n")
             .Replace("\r", "\\r")
             .Replace("\t", "\\t");

        return "\"" + s + "\"";
    }

    private static bool IsNumericType(Type t)
    {
        return t == typeof(byte) || t == typeof(sbyte) ||
               t == typeof(short) || t == typeof(ushort) ||
               t == typeof(int) || t == typeof(uint) ||
               t == typeof(long) || t == typeof(ulong) ||
               t == typeof(float) || t == typeof(double) ||
               t == typeof(decimal);
    }
}

// ------------------- Demo Classes -------------------

public class Student
{
    public int Id;
    private string secretCode = "X-99";

    public string Name { get; set; }
    public int[] Marks { get; set; }
    public Address HomeAddress { get; set; }

    public Student(int id, string name)
    {
        Id = id;
        Name = name;
        Marks = new int[] { 95, 88, 76 };
        HomeAddress = new Address { City = "Delhi", Pin = 110001 };
    }
}

public class Address
{
    public string City { get; set; }
    public int Pin { get; set; }
}

// ------------------- Main -------------------

class GenerateJSONRepresentation
{
    static void Main()
    {
        Student s = new Student(1, "Devansh");

        string jsonLike = JsonReflectionSerializer.ToJsonLike(s);
        Console.WriteLine(jsonLike);
    }
}
