using System;
using System.Reflection;

// Custom Attribute
[AttributeUsage(AttributeTargets.Class)]
public class AuthorAttribute : Attribute
{
    private string name;

    public string Name
    {
        get { return name; }
    }

    public AuthorAttribute(string name)
    {
        this.name = name;
    }
}

// Apply Attribute
[Author("Devansh Singh")]
public class SampleClass
{
    public void Show()
    {
        Console.WriteLine("Inside SampleClass");
    }
}

// Retrieve Attribute at Runtime
class Program
{
    static void Main()
    {
        Type type = typeof(SampleClass);

        AuthorAttribute author =
            (AuthorAttribute)Attribute.GetCustomAttribute(
                type, typeof(AuthorAttribute));

        if (author != null)
        {
            Console.WriteLine("Author Name: " + author.Name);
        }
        else
        {
            Console.WriteLine("Author attribute not found");
        }
    }
}
