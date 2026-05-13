using System;
using System.Collections.Generic;
abstract class CourseType
{
    public string CourseName;
    public abstract void Evaluate();
}

class ExamCourse : CourseType
{
    public ExamCourse()
    {
        CourseName = "Written Course";
    }

    public override void Evaluate()
    {
        Console.WriteLine("Evaluate Marks By Written Exam ");
    }
}

class AssignmentCourse : CourseType
{
    public AssignmentCourse()
    {
        CourseName = "Assignment Course";
    }

    public override void Evaluate()
    {
        Console.WriteLine("Evaluate Marks By Assignment");
    }
}

class Course<T> where T : CourseType
{
    public string CourseName;
    public T CourseEvaluation;

    public Course(string courseName, T courseEvaluation)
    {
        CourseName = courseName;
        CourseEvaluation = courseEvaluation;
    }

    public void Display()
    {
        Console.WriteLine("Course Name: "+CourseName+", Course Evaluation: "+CourseEvaluation.CourseName);
        CourseEvaluation.Evaluate();
    }
}

class CourseManager<T> where T : CourseType
{
    public List<Course<T>> courses = new List<Course<T>>();

    public void AddCourse(Course<T> course)
    {
        courses.Add(course);
    }

    public void ShowCourse()
    {
        Console.WriteLine("\n--------- Course Details ---------");
        for(int i = 0; i < courses.Count; i++)
        {
            courses[i].Display();
        }
    }
}
class CourseManagementSystem
{
    static void Main(string[] args)
    {
        ExamCourse examCourse = new ExamCourse();
        AssignmentCourse assignmentCourse = new AssignmentCourse();

        Course<ExamCourse> exam = new Course<ExamCourse>("C# Programming",examCourse);
        Course<AssignmentCourse> assignment = new Course<AssignmentCourse>("Python",assignmentCourse);

        CourseManager<ExamCourse> examManager = new CourseManager<ExamCourse>();
        CourseManager<AssignmentCourse> assignmentManager = new CourseManager<AssignmentCourse>();

        examManager.AddCourse(exam);
        assignmentManager.AddCourse(assignment);

        examManager.ShowCourse();
        assignmentManager.ShowCourse();
    }
}