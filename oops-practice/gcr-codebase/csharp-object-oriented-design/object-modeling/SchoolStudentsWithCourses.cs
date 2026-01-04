using System;
class Course
{
    public string CourseName;
    private Student[] Students;
    private int StudentCount = 0;

    public Course(string courseName,int maxStudents)
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

    public void ShowStudents()
    {
        Console.WriteLine("Students Enrolled in "+CourseName+":");
        for(int i = 0; i < StudentCount; i++)
        {
            Console.WriteLine("-"+Students[i].StudentName);
        }
    }
}

class Student
{
    public string StudentName;
    private Course[] Courses;
    private int CourseCount = 0;

    public Student(string studentName, int maxCourse)
    {
        StudentName = studentName;
        Courses = new Course[maxCourse];
    }

    public void EnrollCourse(Course course)
    {
        if(CourseCount < Courses.Length)
        {
            Courses[CourseCount++] = course;
            course.AddStudent(this);
        }
    }

    public void ShowCourse()
    {
        Console.WriteLine("Courses enrolled By "+ StudentName+" : ");
        for(int i = 0; i < CourseCount; i++)
        {
            Console.WriteLine("-"+Courses[i].CourseName);
        }
    }
}
class School
{
    public string SchoolName;
    private Student[] Students;
    private int StudentCount = 0;

    public School(string schoolName, int maxStudents)
    {
        SchoolName = schoolName;
        Students = new Student[maxStudents];
    }

    public void AddStudent(Student student)
    {
        if(StudentCount < Students.Length)
        {
            Students[StudentCount++] = student;
        }
    }

    public void ShowSchoolDetails()
    {
        Console.WriteLine("Schoole Name: "+SchoolName);
        Console.WriteLine("Students in School:");

        for(int i = 0; i < StudentCount; i++)
        {
            Console.WriteLine("\nstudent: "+Students[i].StudentName);
            Students[i].ShowCourse();
        }
    }
}

class SchoolStudentsWithCourses
{
    static void Main(string[] args)
    {
        //School (Aggregation)
        School school = new School("ABC Public School",5);

        //Students
        Student s1 = new Student("Devansh",3);
        Student s2 = new Student("Rohit",3);

        //Courses
        Course c1 = new Course("Maths",5);
        Course c2 = new Course("Science",5);
        Course c3 = new Course("Computer",5);

        //Add students to school
        school.AddStudent(s1);
        school.AddStudent(s2);

        //Association
        s1.EnrollCourse(c1);
        s1.EnrollCourse(c3);

        s2.EnrollCourse(c1);
        s2.EnrollCourse(c2);

        //Output
        school.ShowSchoolDetails();

        Console.WriteLine();
        c1.ShowStudents();
        Console.WriteLine();
        c2.ShowStudents();
        Console.WriteLine();
        c3.ShowStudents();
    }
}