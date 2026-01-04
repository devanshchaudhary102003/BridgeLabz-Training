using System;
using System.ComponentModel.DataAnnotations;
class Employee
{
    public string Name;
    public int Id;
    public double Salary;

    public Employee(string name,int id,double salary)
    {
        Name = name;
        Id = id;
        Salary = salary;
    }

    // Virtual method
    public virtual void DisplayDetails()
    {
        Console.WriteLine("Name :"+Name);
        Console.WriteLine("Id :"+Id);
        Console.WriteLine("Salary :"+Salary);
    }
}

class Manager : Employee
{
    public int TeamSize;
    public Manager(string name,int id,double salary,int teamSize) : base(name, id, salary)
    {
        TeamSize = teamSize;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("Manager Details: ");
        base.DisplayDetails();
        Console.WriteLine("Team Size: "+TeamSize);
        Console.WriteLine();
    }
}

class Developer : Employee
{
    public string ProgrammingLanguage;
    public Developer(string name,int id,double salary,string programmingLanguage) : base(name, id, salary)
    {
        ProgrammingLanguage = programmingLanguage;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("Developer Details: ");
        base.DisplayDetails();
        Console.WriteLine("Programming Language: "+ProgrammingLanguage);
        Console.WriteLine();
    }

}

class Intern : Employee
{
    public string  InternshipDuration;
    public Intern(string name,int id,double salary,string internshipDuration) : base(name, id, salary)
    {
         InternshipDuration = internshipDuration;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("Intern Details: ");
        base.DisplayDetails();
        Console.WriteLine(" Internship Duration: "+ InternshipDuration);
        Console.WriteLine();
    }
}
class EmployeeManagement
{
    static void Main(string[] args)
    {
        Employee employee1 = new Manager("Devansh",101,80000,5);
        Employee employee2 = new Developer("Rahul",102,90000,"C#");
        Employee employee3 = new Intern("Rohit",103,70000,"6 Months");

        employee1.DisplayDetails();
        employee2.DisplayDetails();
        employee3.DisplayDetails();
    }
}