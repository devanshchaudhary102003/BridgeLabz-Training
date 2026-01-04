using System;
class Professor
{
    public string ProfessorName;

    public Professor(string professorName)
    {
        ProfessorName = professorName;
    }

    public void AssignProfessor(Courses course)
    {
        course.SetProfessor(this);
        Console.WriteLine("Prof. "+ProfessorName+" assigned to "+course.CourseName);
    }
}
class Student
{
    public string StudentName;
    public Courses[] courses;
    public int CourseCount = 0;

    public Student(string studentName,int maxCourse)
    {
        StudentName = studentName;
        courses = new Courses[maxCourse];
    }

    //Communication: Student enrolls in Course
    public void AddCourse(Courses course)
    {
        if(CourseCount < courses.Length)
        {
            courses[CourseCount++] = course;
            course.AddStudent(this);
            Console.WriteLine(StudentName+" enrolled in "+course.CourseName);
        }
    }

    public void ShowCourse()
    {
        Console.WriteLine("\n Courses of "+StudentName+" :");
        for(int i = 0; i < CourseCount; i++)
        {
            Console.WriteLine("- "+courses[i].CourseName);
        }
    }
}

class Courses
{
    public string CourseName;
    public Student[] Students;
    private int StudentCount = 0;
    private Professor AssignedProfessor;

    public Courses(string courseName,int maxStudents)
    {
        CourseName = courseName;
        Students = new Student[maxStudents];
    }

    public void AddStudent(Student student)
    {
        if(StudentCount < Students.Length)
        {
            Students[StudentCount++] = student;
        }   
    }

    // Aggregation: Course has Professor
    public void SetProfessor(Professor professor)
    {
        AssignedProfessor = professor;
    }

    public void ShowCourseDetails()
    {
        Console.WriteLine("\nCourse: "+CourseName);

        if(AssignedProfessor != null)
        {
            Console.WriteLine("Professor: "+AssignedProfessor.ProfessorName);
        }
        else
        {
            Console.WriteLine("Professor Not Assigned");
        }

        Console.WriteLine("Students Enrolled");
        for(int i = 0; i < StudentCount; i++)
        {
            Console.WriteLine("- "+Students[i].StudentName);
        }
    }
}
class UniversityManagementSystem
{
    static void Main(string[] args)
    {
        // Professors (Independent)
        Professor professor1 = new Professor("Devansh");
        Professor professor2 = new Professor("Rohit");

        // Students (Independent)
        Student student1 = new Student("Aman",3);
        Student student2 = new Student("Aditya",3);

        //Courses
        Courses course1 = new Courses("Computer Science",5);
        Courses course2 = new Courses("Mathematics",5);


        // Assign professors to courses
        professor1.AssignProfessor(course1);
        professor2.AssignProfessor(course2);

        // Students enroll in courses
        student1.AddCourse(course1);
        student2.AddCourse(course2);

        student2.AddCourse(course1);

        // Display course details
        course1.ShowCourseDetails();
        course2.ShowCourseDetails();

        // Display student details
        student1.ShowCourse();
        student2.ShowCourse();
    }
}