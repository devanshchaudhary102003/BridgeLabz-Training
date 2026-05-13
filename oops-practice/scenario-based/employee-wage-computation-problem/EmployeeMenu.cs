using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    sealed class EmployeeMenu
    {
        private IEmployee _employeeChoice;
        public void Menu()
        {
            _employeeChoice = new EmployeeUtilityImpl();


            while (true)
            {
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display Employees");
                Console.WriteLine("3. Attendance Check"); // UC1 Employee Attendance Check
                Console.WriteLine("4. Calculate Daily Wage"); // UC2 Adding Daily Wage
                Console.WriteLine("5. Calculate Monthly Wage"); // UC5 Adding Monthly Wage
                Console.WriteLine("6. Calculate Wage With Max Condition"); // UC6: Calculate Wage with condition
                Console.WriteLine("7. Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)           // UC4 Solving using switch Case
                {
                    case 1:
                        _employeeChoice.AddEmployee(); break;
                    case 2:
                        _employeeChoice.DisplayEmployees(); break;
                    case 3:
                        _employeeChoice.AttendanceCheck(); break; // UC1 Employee Attendance Check
                    case 4:
                        _employeeChoice.EmployeeDailyWage(); break; // UC2 Adding Daily Wage
                    case 5:
                        _employeeChoice.EmployeeMonthlyWage(); break;  //UC5 ADDED MONTHLY WAGE
                    case 6:
                        _employeeChoice.CalculateWageWithCondition(); // UC6: Calculate Wage with condition
                        break;
                    case 7:
                        return;

                }
            }

        }
    }
}