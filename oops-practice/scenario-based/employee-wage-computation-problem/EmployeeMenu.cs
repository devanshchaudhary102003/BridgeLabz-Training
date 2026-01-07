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
                Console.WriteLine("4. Exit");
                
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        _employeeChoice.AddEmployee();
                        break;
                    case 2:
                        _employeeChoice.DisplayEmployee();
                        break;
                    case 3:
                        _employeeChoice.AttendanceCheck();
                        break;
                    case 4:
                        return;
                }
            }
        }
    }
}
