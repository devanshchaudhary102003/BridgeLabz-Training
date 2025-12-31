using System;
class Employee
{
    public int EmployeeId;
    protected string Department;
    private int Salary;

    public Employee(int employeeId,string department,int salary)
    {
        EmployeeId = employeeId;
        Department = department;
        Salary = salary;
    }

    public void SetSalary(int NewSalary)
    {
        Salary = NewSalary;
        Console.WriteLine("Updated Salary:"+Salary);
    }

    public void DisplaySalary()
    {
        Console.WriteLine("Salary: "+Salary);
    }

    public void DisplayDetails()
    {
        Console.WriteLine("--------------- Employee Details ----------------");
        Console.WriteLine("Employee Id:"+EmployeeId);
        Console.WriteLine("Department:"+Department);
    }
}

class Manager : Employee
{
    public Manager(int employeeId,string department,int salary) : base(employeeId, department, salary)
    {
        Console.WriteLine("--------------- Manager Details ----------------");

        // Accessing public member
        Console.WriteLine("Employee ID: " +EmployeeId);

        // Accessing protected member
        Console.WriteLine("Department: " + Department);

        // Cannot access Salary (private)
        // Console.WriteLine(Salary); 

    }
}
class EmployeeRecords
{
    static void Main(string[] args)
    {
        Employee e = new Employee(123,"IT",50000);
        e.DisplayDetails();
        e.DisplaySalary();
        e.SetSalary(65000);

        Manager m = new Manager(159,"HR",80000);
        m.DisplaySalary();
        m.SetSalary(90000);
    }
}