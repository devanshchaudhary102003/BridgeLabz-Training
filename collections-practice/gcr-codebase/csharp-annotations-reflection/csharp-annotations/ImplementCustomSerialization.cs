using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Text;

// 1) Attribute: marks fields/properties for JSON serialization + custom key name
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
public sealed class JsonFieldAttribute : Attribute
{
    public string Name { get; set; }  // Custom JSON key
}

// 2) Example model
public class User
{
    [JsonField(Name = "user_name")]
    public string Username;

    [JsonField(Name = "age")]
    public int Age;

    [JsonField(Name = "is_active")]
    public bool IsActive;

    // Not annotated => will NOT be serialized
    public string Password;

    // You can also annotate properties
    [JsonField(Name = "joined_on")]
    public DateTime JoinedOn { get; set; }
}

// 3) Serializer
public static class JsonAttributeSerializer
{
    public static string ToJson(object obj)
    {
        return SerializeObject(obj);
    }

    private static string SerializeObject(object obj)
    {
        if (obj == null) return "null";

        Type t = obj.GetType();
        var sb = new StringBuilder();
        sb.Append("{");

        bool first = true;

        // Fields
        foreach (var f in t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            var attr = f.GetCustomAttribute<JsonFieldAttribute>();
            if (attr == null) continue;

            string key = string.IsNullOrWhiteSpace(attr.Name) ? f.Name : attr.Name;
            object value = f.GetValue(obj);

            if (!first) sb.Append(",");
            first = false;

            sb.Append("\"").Append(Escape(key)).Append("\":");
            sb.Append(SerializeValue(value));
        }

        // Properties (no indexers)
        foreach (var p in t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            if (p.GetIndexParameters().Length != 0) continue;

            var attr = p.GetCustomAttribute<JsonFieldAttribute>();
            if (attr == null) continue;

            // skip if no getter
            var getter = p.GetGetMethod(nonPublic: true);
            if (getter == null) continue;

            string key = string.IsNullOrWhiteSpace(attr.Name) ? p.Name : attr.Name;
            object value = p.GetValue(obj);

            if (!first) sb.Append(",");
            first = false;

            sb.Append("\"").Append(Escape(key)).Append("\":");
            sb.Append(SerializeValue(value));
        }

        sb.Append("}");
        return sb.ToString();
    }

    private static string SerializeValue(object value)
    {
        if (value == null) return "null";

        Type t = value.GetType();

        // string / char
        if (t == typeof(string)) return "\"" + Escape((string)value) + "\"";
        if (t == typeof(char)) return "\"" + Escape(value.ToString()) + "\"";

        // bool
        if (t == typeof(bool)) return ((bool)value) ? "true" : "false";

        // DateTime -> ISO 8601 string
        if (t == typeof(DateTime))
        {
            var dt = (DateTime)value;
            return "\"" + dt.ToString("o", CultureInfo.InvariantCulture) + "\"";
        }

        // numeric (invariant)
        if (IsNumericType(t))
            return Convert.ToString(value, CultureInfo.InvariantCulture);

        // enum
        if (t.IsEnum) return "\"" + Escape(value.ToString()) + "\"";

        // IEnumerable (but not string)
        if (value is IEnumerable enumerable && value is not string)
        {
            var sb = new StringBuilder();
            sb.Append("[");
            bool first = true;
            foreach (var item in enumerable)
            {
                if (!first) sb.Append(",");
                first = false;
                sb.Append(SerializeValue(item));
            }
            sb.Append("]");
            return sb.ToString();
        }

        // nested object
        return SerializeObject(value);
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

    private static string Escape(string s)
    {
        if (s == null) return "";
        // Minimal JSON escaping
        return s.Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\n", "\\n")
                .Replace("\r", "\\r")
                .Replace("\t", "\\t");
    }
}

// 4) Demo
class ImplementCustomSerialization
{
    static void Main(string[] args)
    {
        var user = new User
        {
            Username = "Devansh",
            Age = 21,
            IsActive = true,
            Password = "secret-should-not-serialize",
            JoinedOn = new DateTime(2026, 1, 29, 9, 15, 0, DateTimeKind.Local)
        };

        string json = JsonAttributeSerializer.ToJson(user);
        Console.WriteLine(json);
    }
}
