using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Employee
{
    public int Id;
    public string Name;
    public string Department;
    public decimal Salary;
}

class SortCsvBySalary
{
    static void Main(string[] args)
    {
        string filePath = "employeesss.csv";

        List<Employee> employees = new List<Employee>();

        string[] lines = File.ReadAllLines(filePath);

        for(int i = 1; i < lines.Length; i++)
        {
            string[] data = lines[i].Split(',');

            employees.Add(new Employee
            {
                Id = int.Parse(data[0]),
                Name = data[1],
                Department = data[2],
                Salary = decimal.Parse(data[3])
            });
        }

        var topEmployees = employees.OrderByDescending(e => e.Salary).Take(5);

        Console.WriteLine("Top % Highest-Paid Employees:\n");

        foreach(var emp in topEmployees)
        {
            Console.WriteLine("Name: " + emp.Name +", Department: " + emp.Department +", Salary: " + emp.Salary);
        }
    }
}