using System;
using System.Reflection;


[AttributeUsage(AttributeTargets.Field)]
public class RequiredAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Field)]
public class MinLengthAttribute : Attribute
{
    public int Value { get; }

    public MinLengthAttribute(int value)
    {
        Value = value;
    }
}

[AttributeUsage(AttributeTargets.Field)]
public class MaxLengthAttribute : Attribute
{
    public int Value { get; }

    public MaxLengthAttribute(int value)
    {
        Value = value;
    }
}


public class User
{
    [Required]
    [MinLength(4)]
    [MaxLength(10)]
    private string Username;

    public User(string username)
    {
        ValidateField("Username", username);
        Username = username;
    }

    private void ValidateField(string fieldName, string value)
    {
        FieldInfo field = typeof(User).GetField(
            fieldName,
            BindingFlags.Instance | BindingFlags.NonPublic
        );

        if (field == null)
            throw new ArgumentException("Field '" + fieldName + "' not found.");

        if (field.IsDefined(typeof(RequiredAttribute), false))
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(fieldName + " is required.");
        }

        MinLengthAttribute minAttr =
            field.GetCustomAttribute<MinLengthAttribute>();

        if (minAttr != null && value != null && value.Length < minAttr.Value)
        {
            throw new ArgumentException(
                fieldName + " must be at least " + minAttr.Value + " characters."
            );
        }

        MaxLengthAttribute maxAttr =
            field.GetCustomAttribute<MaxLengthAttribute>();

        if (maxAttr != null && value != null && value.Length > maxAttr.Value)
        {
            throw new ArgumentException(
                fieldName + " must not exceed " + maxAttr.Value + " characters."
            );
        }
    }

    public void Display()
    {
        Console.WriteLine("Username: " + Username);
    }
}


class MaxLengthAttribute
{
    static void Main()
    {
        try
        {
            User u1 = new User("Devansh");
            u1.Display();

            User u2 = new User("Ab");                
            u2.Display();

            User u3 = new User("VeryLongUserName");  
            u3.Display();

            User u4 = new User("");                  
            u4.Display();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
