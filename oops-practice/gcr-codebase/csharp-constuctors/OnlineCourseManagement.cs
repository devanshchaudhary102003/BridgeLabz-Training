using System;
public class Course
{
    public string CourseName;
    public int Duration;
    public int Fee;

    static string InstituteName;

    public Course(string courseName,int duration,int fee)
    {
        CourseName = courseName;
        Duration = duration;
        Fee = fee;
    }
    public void DisplayCourseDetails()
    {
        Console.WriteLine("Course Name:"+CourseName);
        Console.WriteLine("Duration:"+Duration);
        Console.WriteLine("Fee:"+Fee);
    }

    public static void UpdateInstituteName(string newName)
    {
        InstituteName = newName;  
        Console.WriteLine("Institute Name:"+InstituteName);      
    }
}
class OnlineCourseManagement
{
    static void Main(string[] args)
    {
        Course c1 = new Course("Btech",4,200000);
        c1.DisplayCourseDetails();
        Course.UpdateInstituteName("GLA University");

        Course c2 = new Course("BCA",3,100000);
        c2.DisplayCourseDetails();
        Course.UpdateInstituteName("Galgotia University");
    }
}