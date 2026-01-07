using System;
using System.Collections.Generic;
using System.Linq;
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
                Console.WriteLine("2. Display Employee");
                Console.WriteLine("3. Attendance Check");   //UC1 Employee Attendance Check
                Console.WriteLine("4. Calculate Daily Wage"); // UC2 Adding Daily Wage
                Console.WriteLine("5. Calculate Monthly Wage"); // UC5 Adding Monthly Wage
                Console.WriteLine("6. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)             //UC4 Solving using switch Case
                {
                    case 1:
                        _employeeChoice.AddEmployee();
                        break;
                    case 2:
                        _employeeChoice.DisplayEmployees();
                        break;
                    case 3:
                        _employeeChoice.AttendanceCheck();
                        break;
                    case 4:
                        _employeeChoice.EmployeeDailyWage();
                        break;
                    case 5:
                        _employeeChoice.EmployeeMonthlyWage(); //UC5 ADDED MONTHLY WAGE
                        break;  
                    case 6:
                        return;
                }
            }
        }
    }
}
