using System;
class Employee
{
    public string Name;
    public Employee(string name)
    {
        Name = name;
        Console.WriteLine("Employee Created: "+Name);
    }
}

class Department
{
    public string DepartmentName;
    private Employee[] employees;
    private int empCount = 0;

    public Department(string departmentName,int maxEmployees)
    {
        DepartmentName = departmentName;
        employees = new Employee[maxEmployees];     //employees object
        Console.WriteLine("Department Created: "+DepartmentName);
    }

    public void AddEmployee(string empName)
    {
        if(empCount < employees.Length)
        {
            employees[empCount++] = new Employee(empName);
        }
        else
        {
            Console.WriteLine("Employee limit exceed "+DepartmentName);
        }
    }
}

class Company
{
    public string CompanyName;
    private Department[] departments;
    private int deptCount = 0;

    public Company(string companyName,int maxDepartment)
    {
        CompanyName = companyName;
        departments = new Department[maxDepartment];
        Console.WriteLine("Company Created: "+CompanyName);
    }
    public void CreateDepartment(string deptName, int maxEmployees)
    {
        if(deptCount < departments.Length)
        {
            departments[deptCount] = new Department(deptName,maxEmployees);
            deptCount++;
        }
        else
        {
            Console.WriteLine("Department limit reached in company");
        }
    }

    public Department GetDepartment(int index)
    {
        return departments[index];
    }
}
class CompanyAndDepartments
{
    static void Main(string[] args)
    {
        Company company = new Company("Capgemini",2);

        company.CreateDepartment("IT",2);
        company.CreateDepartment("HR",2);

        Department it = company.GetDepartment(0);
        it.AddEmployee("IT: Devansh");
        it.AddEmployee("IT: Rohit");

        Department hr = company.GetDepartment(1);
        hr.AddEmployee("HR: Pankaj");
        hr.AddEmployee("HR: Pandey");
    }
}