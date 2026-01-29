using System;
using System.IO;

class SearchEmployeeCSV
{
    static void Main(string[] args)
    {
        string filePath = "employee.csv";

        Console.WriteLine("Enter employee name to search: ");
        string searchName = Console.ReadLine();

        bool found = false;

        using(StreamReader reader = new StreamReader(filePath))
        {
            string line;

            reader.ReadLine();

            while((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(',');

                string name = data[1];

                if(name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    string department = data[2];
                    string salary = data[3];

                    Console.WriteLine("Employee Found!");
                    Console.WriteLine("Department: "+department);
                    Console.WriteLine("Salary: "+salary);

                    found = true;
                    break;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Employee Not Found");
        }
    }
}