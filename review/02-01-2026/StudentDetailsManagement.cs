using System;
class Student
{
    public int StudentID;
    public string StudentName;
    public int Age;

    public int[] marks;

    public string[] subject;


    public Student(int StudentID,string StudentName,int Age,int[] marks,string[] subject)
    {
        this.StudentID = StudentID;
        this.StudentName = StudentName;
        this.Age = Age;
        this.marks = marks;
        this.subject = subject;
    }

    public void DisplayStudentDetails()
    {
        Console.WriteLine("Student ID :"+StudentID);
        Console.WriteLine("Student Name :"+StudentName);
        Console.WriteLine("Student Age :"+Age);

        for(int i = 0; i < 3; i++)
        {
            Console.WriteLine("Subject "+subject[i]);
        }
        for(int i = 0; i < 3; i++)
        {
            Console.WriteLine("Subject Marks: "+marks[i]);
        }
    }
}
class StudentDetailsManagement
{
    static void Main(string[] args)
    {
        string[] subject = new string[3];
        for(int i = 0; i < subject.Length; i++)
        {
            Console.WriteLine("Enter Subject:");
            subject[i] = Console.ReadLine();
        }
        
        int[] marks = new int[3];
        for(int i = 0; i < marks.Length; i++)
        {
            Console.WriteLine("Enter marks:");
            marks[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Enter Student ID:");
        int StudentID = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Student Name:");
        string Name = Console.ReadLine();

        Console.WriteLine("Enter Student Age:");
        int Age = Convert.ToInt32(Console.ReadLine());

        Student s1 = new Student(StudentID,Name,Age,marks,subject);

        if(s1 is Student)
        {
            Console.WriteLine("s1 is a Student object");
            s1.DisplayStudentDetails();
        }
    }
}