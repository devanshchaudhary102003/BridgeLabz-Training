using System;
using System.Reflection;

class Person
{
    private int age;

    public Person(int age)
    {
        this.age = age;
    }
}

class AccessPrivateField
{
    static void Main(string[] args)
    {
        // Create object of Person
        Person person = new Person(25);

        // Get Type of Person class
        Type type = typeof(Person);

        // Get private field 'age'
        FieldInfo fieldInfo = type.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);

        // Read private field value
        int originalAge = (int)fieldInfo.GetValue(person);
        Console.WriteLine("Original Age: " + originalAge);

        // Modify private field value
        fieldInfo.SetValue(person, 30);

        // Read modified value
        int modifiedAge = (int)fieldInfo.GetValue(person);
        Console.WriteLine("Modified Age: " + modifiedAge);
    }
}
