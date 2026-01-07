using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class EmployeeUtilityImpl : IEmployee
    {
        private List<Employee> employees = new List<Employee>();
        private Employee employee;
        private Random attendanceCheck = new Random();

        public Employee AddEmployee()
        {
            employee = new Employee();

            Console.WriteLine("1. Full time Employee");
            Console.WriteLine("2. Part Time Employee");

            int choicefortime = int.Parse(Console.ReadLine());

            if (choicefortime == 1)
            {
                Console.Write("Enter Employee ID: ");
                employee.EmployeeId = Console.ReadLine();

                Console.Write("Enter Name: ");
                employee.EmployeeName = Console.ReadLine();

                Console.Write("Enter Phone: ");
                employee.EmployeePhoneNumber = long.Parse(Console.ReadLine());

                employees.Add(employee);

                Console.WriteLine("Employee Added Successfully!");
                return employee;
            }
            else  // UC3 Added PartTIme Employees and Wage
            {
                employee.IsPartTime = true;
                Console.Write("Enter PartTime Employee ID: ");
                employee.EmployeeId = Console.ReadLine();

                Console.Write("Enter Name: ");
                employee.EmployeeName = Console.ReadLine();

                Console.Write("Enter Phone: ");
                employee.EmployeePhoneNumber = long.Parse(Console.ReadLine());

                employees.Add(employee);

                Console.WriteLine("Employee Added Successfully!");
                return employee;
            }


        }

        // UC1 Employee Attendance Check
        public void AttendanceCheck()
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"Employee {employee.EmployeeName} attendance : ");
                long attendaceOtp = attendanceCheck.Next(1, 100000);
                Console.WriteLine($"Enter The Number Displayed {attendaceOtp}");

                long employeeinput = long.Parse(Console.ReadLine());
                if (attendaceOtp == employeeinput)
                    employee.EmployeeAttendance = "Present";
                else
                    employee.EmployeeAttendance = "Abesent";
            }
        }

        // UC2 Adding Daily Wage

        private double wageperhour = 20;
        public void EmployeeDailyWage()
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"How many hours employee {employee.EmployeeName} worked for? ");
                int hourinput = int.Parse(Console.ReadLine());
                if (hourinput > 8)
                    Console.WriteLine("Can't be greater than 8");
                else
                    employee.EmployeeDailyWage = wageperhour * hourinput;
                Console.WriteLine($"Your total wage is : {employee.EmployeeDailyWage}");
            }
        }


        public void DisplayEmployees()
        {
            Console.WriteLine("1. Display Full time Employees");
            Console.WriteLine("2. Display Part Time Employee"); // UC3 Added PartTIme Employees and Wage

            int choicefortime = int.Parse(Console.ReadLine());

            if (choicefortime == 1)
            {
                foreach (Employee employee in employees)
                {
                    if (!employee.IsPartTime)
                    {
                        Console.WriteLine(employee);
                        Console.WriteLine("-----------\n");
                    }
                }
            }
            else
            {
                foreach (Employee employee in employees) // UC3 Added PartTIme Employees and Wage
                {
                    if (employee.IsPartTime)
                    {
                        Console.WriteLine(employee);
                        Console.WriteLine("-----------\n");
                    }
                }
            }

        }
    }
}