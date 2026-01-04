using System;

class Person
{
    public string Name;
    public int Id;

    public Person(string name, int id)
    {
        Name = name;
        Id = id;
    }

    // Common method
    public virtual void PerformDuties()
    {
        Console.WriteLine("Person is working.");
    }
}

class Chef : Person
{
    public Chef(string name, int id) : base(name, id) { }

    public override void PerformDuties()
    {
        Console.WriteLine("Chef Duties:");
        Console.WriteLine(Name + " is cooking food.");
        Console.WriteLine();
    }
}

class Waiter : Person
{
    public Waiter(string name, int id) : base(name, id) { }

    public override void PerformDuties()
    {
        Console.WriteLine("Waiter Duties:");
        Console.WriteLine(Name + " is serving customers.");
        Console.WriteLine();
    }
}

class RestaurantManagementSystem 
{
    static void Main()
    {
        Person p1 = new Chef("Rahul", 101);
        Person p2 = new Waiter("Amit", 102);

        p1.PerformDuties();
        p2.PerformDuties();
    }
}
