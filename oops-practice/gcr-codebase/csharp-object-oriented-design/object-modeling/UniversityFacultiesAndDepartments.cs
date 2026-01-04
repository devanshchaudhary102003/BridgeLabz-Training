using System;
class Faculty
{
    public string FacultyName;

    public Faculty(string facultyName)
    {
        FacultyName = facultyName;
    }

    public void ShowFaculty()
    {
        Console.WriteLine("Faculty Name: "+FacultyName);
    }
}

class Department
{
    public string DepartmentName;
    public Faculty[] Faculties;
    public int FacultyCount = 0;

    public Department(string departmentName,int maxFaculty)
    {
        DepartmentName = departmentName;
        Faculties = new Faculty[maxFaculty];
    }

    public void AddFaculty(Faculty faculty)
    {
        if(FacultyCount < Faculties.Length)
        {
            Faculties[FacultyCount++] = faculty;
        }
    }

    public void ShowDepartmentDetails()
    {
        Console.WriteLine("\n Department Name: "+DepartmentName);
        Console.WriteLine("Faculties");

        for(int i = 0; i < FacultyCount; i++)
        {
            Console.WriteLine("- "+Faculties[i].FacultyName);
        }
    }
}

class University
{
    public string UniversityName;
    public Department[] departments;
    public int DepartmentCount = 0;

    public University(string universityName, int maxDepartment)
    {
        UniversityName = universityName;
        departments = new Department[maxDepartment];
    }

    public void AddDepartment(string deptName,int maxFaculty)
    {
        if(DepartmentCount < departments.Length)
        {
            departments[DepartmentCount++] = new Department(deptName,maxFaculty);
        }
    }

    public Department GetDepartment(int index)
    {
        if(index >= 0 && index < DepartmentCount)
        {
            return departments[index];
        }
        return null;
    }

    public void ShowUniversityDetails()
    {
        Console.WriteLine("University: "+UniversityName);

        for(int i = 0; i < DepartmentCount; i++)
        {
            departments[i].ShowDepartmentDetails();
            Console.WriteLine();
        }
    }

    // Composition behavior
    public void DeleteUniversity()
    {
        departments = null;
        DepartmentCount=0;
        Console.WriteLine("University Deleted. All departments removed.");
    }
}
class UniversityFacultiesAndDepartments
{
    static void Main(string[] args)
    {
        // Independent Faculty (Aggregation)
        University university = new University("GLA University",3);

        // University (Composition)
        Faculty f1 = new Faculty("Dr. Devansh");
        Faculty f2 = new Faculty("Dr. Rohit");
        Faculty f3 = new Faculty("Dr. Mehta");

        university.AddDepartment("Computer Science",3);
        university.AddDepartment("Mechanical",2);

         // Assign faculty to departments
        university.GetDepartment(0).AddFaculty(f1);
        university.GetDepartment(0).AddFaculty(f2);

        university.GetDepartment(1).AddFaculty(f3);

        // Display
        university.ShowUniversityDetails();

        Console.WriteLine("Faculty still exists independently: ");
        f1.ShowFaculty();

        //Delete University
        university.DeleteUniversity();
    }
}