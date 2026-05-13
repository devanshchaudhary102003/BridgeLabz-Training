using System;

class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void DisplayRole()
    {
        Console.WriteLine("Role: Person");
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
    }
}

class Teacher : Person
{
    public string Subject;

    public Teacher(string name, int age, string subject)
        : base(name, age)
    {
        Subject = subject;
    }

    public override void DisplayRole()
    {
        Console.WriteLine("Role: Teacher");
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Subject: " + Subject);
        Console.WriteLine();
    }
}

class Student : Person
{
    public string Grade;

    public Student(string name, int age, string grade)
        : base(name, age)
    {
        Grade = grade;
    }

    public override void DisplayRole()
    {
        Console.WriteLine("Role: Student");
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Grade: " + Grade);
        Console.WriteLine();
    }
}

class Staff : Person
{
    public string Department;

    public Staff(string name, int age, string department)
        : base(name, age)
    {
        Department = department;
    }

    public override void DisplayRole()
    {
        Console.WriteLine("Role: Staff");
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Department: " + Department);
        Console.WriteLine();
    }
}

class SchoolSystemwithDifferentRoles

{
    static void Main()
    {
        Person[] people = new Person[3];

        people[0] = new Teacher("Mr. Sharma", 40, "Mathematics");
        people[1] = new Student("Aman", 16, "10th Grade");
        people[2] = new Staff("Ramesh", 35, "Administration");

        for (int i = 0; i < people.Length; i++)
        {
            people[i].DisplayRole(); // Polymorphism
        }
    }
}
