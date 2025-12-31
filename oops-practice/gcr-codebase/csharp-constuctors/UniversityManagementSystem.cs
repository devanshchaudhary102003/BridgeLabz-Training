using System;
class Student
{
    public int RollNumber;      // Accessible everywhere
    protected string Name;         // Accessible in the same assembly and subclasses
    private double CGPA;           // Accessible only within the class

    public Student(int rollNumber,string name,double cgpa)
    {
        RollNumber = rollNumber;
        Name = name;
        CGPA = cgpa;
    }

    public void DisplayCGPA()
    {
        Console.WriteLine("CGPA: "+CGPA);
    }

    public void ModifyCGPA(double newCGPA)
    {
        CGPA = newCGPA;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("------------Student Details--------------");
        Console.WriteLine("Roll Number: "+RollNumber);
        Console.WriteLine("Name: "+Name);
    }
}

class PostgraduateStudent : Student
{
    public PostgraduateStudent(int rollNumber, string name, double cgpa) : base(rollNumber, name, cgpa)
    {
        
    }
}
class UniversityManagementSystem
{
    static void Main(string[] args)
    {
        Student s = new Student(2215,"Devansh",8.2);
        s.DisplayDetails();
        s.DisplayCGPA();
        s.ModifyCGPA(9.1);
        s.DisplayDetails();
        s.DisplayCGPA();

        Console.WriteLine();

        Console.WriteLine("------------- Postgraduate ---------------");
        PostgraduateStudent pg = new PostgraduateStudent(2415,"Akash",8.5);
        pg.DisplayDetails();
        pg.DisplayCGPA();
        pg.ModifyCGPA(8.7);
        pg.DisplayDetails();
        pg.DisplayCGPA();
    }
}