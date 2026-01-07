using System;
//Interface
interface IDepartment
{
    void AssignDepartment(string DeptName);
    string GetDepartmentDetails();
}
abstract class Employee:IDepartment
{
    private int EmployeeId;
    private string Name;
    private double BaseSalary;
    private string Department;

    // Getter & Setter
    public int employeeId
    {
        get
        {
            return EmployeeId;
        }
         set
        {
            EmployeeId = value;
        }
    }

    public string name
    {
        get
        {
            return Name;
        }
         set
        {
            Name = value;
        }
    }

    public double baseSalary
    {
        get
        {
            return BaseSalary;
        }
         set
        {
            BaseSalary = value;
        }
    }

    //abstract method
    public abstract double CalculateSalary();

    //concrete method
    public void DisplayDetails()
    {
        Console.WriteLine("Employee Id: "+EmployeeId);
        Console.WriteLine("Employee Name: "+Name);
        Console.WriteLine("Department Name: "+Department);
        Console.WriteLine("Total Salary: " + CalculateSalary());
        Console.WriteLine("-----------------------------");
    }

    //Interface method
    public void AssignDepartment(string DeptName)
    {
        Department = DeptName;
    }

    public string GetDepartmentDetails()
    {
        return Department;
    }
}

class FullTimeEmployee : Employee
{
    //Overriding the abstract method
    public override double CalculateSalary()
    {
        return  baseSalary+5000; //fixed Salary
    }
}

class PartTimeEmployee : Employee
{
    private int hoursWorked;
    private double hourlyRate;

    public int HoursWorked
    {
        get { return hoursWorked; }
        set { hoursWorked = value; }
    }

    public double HourlyRate
    {
        get { return hourlyRate; }
        set { hourlyRate = value; }
    }

    public override double CalculateSalary()
    {
        return HoursWorked*HourlyRate;
    }
}
class EmployeeManagementSystem
{
    static void Main(string[] args)
    {
        //Array of Employee (Polymorphism)
        Employee[] employee = new Employee[2];

        FullTimeEmployee fullTimeEmployee = new FullTimeEmployee();
        fullTimeEmployee.employeeId = 101;
        fullTimeEmployee.name = "Devansh";
        fullTimeEmployee.baseSalary = 30000;
        fullTimeEmployee.AssignDepartment("IT");

        employee[0] = fullTimeEmployee;

        PartTimeEmployee partTimeEmployee = new PartTimeEmployee();
        partTimeEmployee.employeeId = 102;
        partTimeEmployee.name = "Rohit";
        partTimeEmployee.HoursWorked = 40;
        partTimeEmployee.HourlyRate = 500;
        partTimeEmployee.AssignDepartment("HR");

        employee[1] = partTimeEmployee;

        for(int i = 0; i < employee.Length; i++)
        {
            employee[i].DisplayDetails();
        }

        Console.ReadLine();
    }
}