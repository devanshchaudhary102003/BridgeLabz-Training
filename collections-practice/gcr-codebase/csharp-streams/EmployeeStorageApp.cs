using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
class Employee
{
    public int Id;
    public string Name;
    public string Department;
    public double Salary;
}

class EmployeeStorageApp
{
    static void Main()
    {
        string filePath = "employees.dat";
        List<Employee> employees = new List<Employee>();

        try
        {
            Console.Write("Enter number of employees: ");
            int count = Convert.ToInt32(Console.ReadLine());

            // ----------- INPUT EMPLOYEES -----------
            for (int i = 0; i < count; i++)
            {
                Employee emp = new Employee();

                Console.WriteLine("\nEnter details for Employee " + (i + 1));

                Console.Write("Id: ");
                emp.Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Name: ");
                emp.Name = Console.ReadLine();

                Console.Write("Department: ");
                emp.Department = Console.ReadLine();

                Console.Write("Salary: ");
                emp.Salary = Convert.ToDouble(Console.ReadLine());

                employees.Add(emp);
            }

            // ----------- SERIALIZATION -----------
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, employees);
            }

            Console.WriteLine("\nEmployees saved to file successfully.");

            // ----------- DESERIALIZATION -----------
            List<Employee> loadedEmployees;

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                loadedEmployees = (List<Employee>)formatter.Deserialize(fs);
            }

            // ----------- DISPLAY DATA -----------
            Console.WriteLine("\nEmployees retrieved from file:\n");

            foreach (Employee e in loadedEmployees)
            {
                Console.WriteLine(
                    "Id: " + e.Id +
                    ", Name: " + e.Name +
                    ", Department: " + e.Department +
                    ", Salary: " + e.Salary
                );
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("File I/O Error: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }
}
