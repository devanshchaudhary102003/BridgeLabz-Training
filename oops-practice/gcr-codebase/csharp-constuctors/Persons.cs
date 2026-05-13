using System;
public class Person
{
    public string name;
    public int age;
    public string place;

    // Parameterized Constructor
    public Person(string Name,int Age,string Place)
    {
        name = Name;
        age = Age;
        place = Place;
    }

    // Copy Constructor
    public Person(Person PreviousPerson)
    {
        name = PreviousPerson.name;
        age = PreviousPerson.age;
        place = PreviousPerson.place;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("---------Person Details-------------");
        Console.WriteLine("Person Name:"+name);
        Console.WriteLine("Person Age:"+age);
        Console.WriteLine("Person's Place:"+place);
    }
}
public class Persons
{
    static void Main(string[] args)
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter Place: ");
        string place = Console.ReadLine();

        Person per = new Person(name,age,place);
        per.DisplayDetails();

        Person per2 = new Person(per);
        Console.WriteLine("=======================Copied Person Details=========================");
        per2.DisplayDetails();
    }
}