using System;
using System.Reflection;

class Student
{
    public int Id;
    public string Name;

    public Student()
    {
        Id = 0;
        Name = "Unknown";
    }

    public void Display()
    {
        Console.WriteLine("Id: " + Id);
        Console.WriteLine("Name: " + Name);
    }
}

class DynamicallyCreateObjects
{
    static void Main()
    {
        // Get Student class metadata
        Type type = typeof(Student);

        // Create object dynamically (without new)
        object studentObj = Activator.CreateInstance(type);

        // Set fields dynamically
        type.GetField("Id").SetValue(studentObj, 101);
        type.GetField("Name").SetValue(studentObj, "Devansh");

        // Call method dynamically
        type.GetMethod("Display").Invoke(studentObj, null);
    }
}
