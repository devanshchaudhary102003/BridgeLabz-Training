using System;
class Employee
{
    public static string CompanyName = "CAPGEMINI";
    public string Name;
    public readonly int EmployeeID;
    public string Designation;
    private static int totalEmplyees = 0;

    public Employee(string Name,int EmployeeID,string Designation)
    {
        this.Name = Name;
        this.EmployeeID = EmployeeID;
        this.Designation = Designation;
        totalEmplyees++;

    }
    public static void DisplayTotalEmplyees()
    {
        Console.WriteLine("Total Employees:"+totalEmplyees);
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Company Name:"+CompanyName);
        Console.WriteLine("Employee Name:"+Name);
        Console.WriteLine("Employee ID:"+EmployeeID);
        Console.WriteLine("Employee Designation:"+Designation);
    }
}
class EmployeeManagementSystem
{
    static void Main(string[] args)
    {
        Employee e1 = new Employee("Devansh",2215,"Manager");
        Employee e2 = new Employee("Rohit",2185,"HR");
        

        if(e1 is Employee)
        {
            Console.WriteLine("e1 is a Employee object");
            e1.DisplayDetails();
        }

        Console.WriteLine();

        if(e2 is Employee)
        {
            Console.WriteLine("e2 is a Employee object");
            e2.DisplayDetails();
        }

        Console.WriteLine();

        Employee.DisplayTotalEmplyees();
    }
}