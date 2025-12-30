using System;
public class Employee
{
    public string name;
    public int id;
    public int salary;

    public void DisplayDetails()
    {
        Console.WriteLine("Enters Employee Name:");
        name = Console.ReadLine();

        Console.WriteLine("Enters Employee Id:");
        id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Employee Salary:");
        salary = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Employee Details:");
        Console.WriteLine("Employee Name:"+name);
        Console.WriteLine("Employee Id:"+id);
        Console.WriteLine("Employee Salary:"+salary);
    }
}
public class EmployeeDetails
{
    static void Main(string[] args)
    {
        Employee employee = new Employee();

        employee.DisplayDetails();
    }
}