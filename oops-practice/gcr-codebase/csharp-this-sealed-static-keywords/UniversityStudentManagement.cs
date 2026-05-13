using System;
class Student
{
    public static string UniversityName = "GLA University";
    public static int TotalStudents ;
    public string Name;
    public readonly int RollNumber;
    public string Grade;

    public Student(string Name,int RollNumber,string Grade)
    {
        this.Name = Name;
        this.RollNumber = RollNumber;
        this.Grade = Grade;
        TotalStudents++;
    }
    public void DisplayDetails()
    {
        Console.WriteLine("University Name:"+UniversityName);
        Console.WriteLine("Name :"+Name);
        Console.WriteLine("Roll Number:"+RollNumber);
        Console.WriteLine("Grade:"+Grade);
    }
    public static void DisplayTotalStudents()
    {
        Console.WriteLine("Total Number of Student:"+TotalStudents);
    }
}
class UniversityStudentManagement
{
    static void Main(string[] args)
    {
        Student s1 = new Student("Devansh",2215,"A");
        Student s2 = new Student("Rohit",2456,"B");

        if(s1 is Student)
        {
            Console.WriteLine("s1 is a Student object");
            s1.DisplayDetails();
        }

        Console.WriteLine();

        if(s2 is Student)
        {
            Console.WriteLine("s2 is a Student object");
            s2.DisplayDetails();
        }

        Console.WriteLine();

        Student.DisplayTotalStudents();
    }
}