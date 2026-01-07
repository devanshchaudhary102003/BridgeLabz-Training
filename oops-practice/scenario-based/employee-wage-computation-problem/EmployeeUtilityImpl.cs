using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class EmployeeUtilityImpl:IEmployee
    {
        private List<Employee> employees = new List<Employee>();
        private Employee employee;
        private Random attendanceCheck = new Random();

        public Employee AddEmployee()
        {
            employee = new Employee();
            Console.WriteLine("Enter ID: ");
            employee.EmployeeId = Console.ReadLine();

            Console.WriteLine("Enter Name: ");
            employee.EmployeeName = Console.ReadLine();

            Console.WriteLine("Enter Phone Number: ");
            employee.EmployeePhoneNumber = long.Parse(Console.ReadLine());

            employees.Add(employee);

            Console.WriteLine("Employee Added Successfully!");
            return employee;
        }

        //UC1 Employee Attendance Check
        public void AttendanceCheck()
        {
            int i = 1;
            
            foreach(Employee employee in employees)
            {
                Console.WriteLine($"Employee {i} attendance : ");
                long attendanceOtp = attendanceCheck.Next(1, 100000);
                i++;
                Console.WriteLine($"Enter The Number Displayed {attendanceOtp}");

                long employeeinput = long.Parse(Console.ReadLine());
                if (attendanceOtp == employeeinput)
                    employee.EmployeeAttendance = "Present";
                else
                    employee.EmployeeAttendance = "Absent";
            }
        }

        public void DisplayEmployee()
        {
            foreach(Employee employee in employees)
            {
                Console.WriteLine(employee);
                Console.WriteLine("---");
            }
        }
    }
}
