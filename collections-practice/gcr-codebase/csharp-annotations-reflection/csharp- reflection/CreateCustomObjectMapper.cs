using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

public static class ObjectMapper
{
    // Custom Object Mapper
    public static T ToObject<T>(Type clazz, Dictionary<string, object> properties)
    {
        if (clazz == null)
            throw new ArgumentNullException("clazz");

        if (properties == null)
            throw new ArgumentNullException("properties");

        if (!typeof(T).IsAssignableFrom(clazz))
            throw new ArgumentException("Type mismatch");

        object instance = Activator.CreateInstance(clazz, true);

        BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        Dictionary<string, PropertyInfo> propMap =
            clazz.GetProperties(flags)
                 .Where(p => p.GetIndexParameters().Length == 0)
                 .ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);

        Dictionary<string, FieldInfo> fieldMap =
            clazz.GetFields(flags)
                 .ToDictionary(f => f.Name, StringComparer.OrdinalIgnoreCase);

        foreach (KeyValuePair<string, object> pair in properties)
        {
            string name = pair.Key;
            object value = pair.Value;

            // Prefer properties (best practice)
            if (propMap.ContainsKey(name))
            {
                PropertyInfo prop = propMap[name];
                MethodInfo setter = prop.GetSetMethod(true);

                if (setter != null)
                {
                    object converted = ConvertValue(value, prop.PropertyType);
                    setter.Invoke(instance, new object[] { converted });
                    continue;
                }
            }

            // Fallback to fields
            if (fieldMap.ContainsKey(name))
            {
                FieldInfo field = fieldMap[name];
                object converted = ConvertValue(value, field.FieldType);
                field.SetValue(instance, converted);
            }
        }

        return (T)instance;
    }

    private static object ConvertValue(object value, Type targetType)
    {
        if (value == null)
        {
            if (!targetType.IsValueType || Nullable.GetUnderlyingType(targetType) != null)
                return null;

            return Activator.CreateInstance(targetType);
        }

        if (targetType.IsInstanceOfType(value))
            return value;

        Type nullable = Nullable.GetUnderlyingType(targetType);
        if (nullable != null)
            return ConvertValue(value, nullable);

        if (targetType.IsEnum)
        {
            if (value is string)
                return Enum.Parse(targetType, value.ToString(), true);

            object enumValue =
                Convert.ChangeType(value, Enum.GetUnderlyingType(targetType), CultureInfo.InvariantCulture);

            return Enum.ToObject(targetType, enumValue);
        }

        if (targetType == typeof(Guid))
            return Guid.Parse(value.ToString());

        if (targetType == typeof(DateTime))
            return DateTime.Parse(value.ToString(), CultureInfo.InvariantCulture);

        return Convert.ChangeType(value, targetType, CultureInfo.InvariantCulture);
    }
}

// Sample class (fixed: use property instead of field, no CS0649 warning)
class Person
{
    public int Id { get; private set; }   // private setter is OK with reflection
    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return "Id=" + Id + ", Name=" + Name + ", Age=" + Age;
    }
}

class CreateCustomObjectMapper
{
    static void Main()
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        data.Add("Id", 101);
        data.Add("Name", "Devansh");
        data.Add("Age", "22"); // string -> int conversion

        Person person = ObjectMapper.ToObject<Person>(typeof(Person), data);
        Console.WriteLine(person.ToString());
    }
}
