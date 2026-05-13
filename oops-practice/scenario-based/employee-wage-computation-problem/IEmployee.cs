using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal interface IEmployee
    {
        Employee AddEmployee();
        void DisplayEmployees();
        void AttendanceCheck();  // UC1 Employee Attendance Check
        void EmployeeDailyWage(); // UC2 Adding Daily Wage
        void EmployeeMonthlyWage();  //UC5 ADDED MONTHLY WAGE

        void CalculateWageWithCondition();  // UC6: Calculate Wage with condition

    }
}