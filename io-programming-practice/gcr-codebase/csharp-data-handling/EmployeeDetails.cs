using System;
using System.IO;

class EmployeeDetails
{
    static void Main(string[] args)
    {
        string filePath = "employees.csv";

        string[] employees =
        {
            "ID,Name,Department,Salary",
            "1,Amit Sharma,IT,60000",
            "2,Priya Verma,HR,45000",
            "3,Rahul Singh,Finance,55000",
            "4,Neha Gupta,Marketing,50000",
            "5,Arjun Mehta,Sales,48000"
        };

        File.WriteAllLines(filePath, employees);

        Console.WriteLine("Employee data written to CSV file successfully.");
    }
}
