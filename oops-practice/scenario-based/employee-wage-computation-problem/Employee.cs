using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class Employee
    {
        private string employeeid;
        private string employeename;
        private double employeedailywage;  // UC2 Adding Daily Wage
        private long employeephonenumber;

        private string employeeattendance;   // UC1 Employee Attendance Check
        private bool isparttime = false; //UC3 Added PartTIme Employees and Wage
        private double employeemonthlywage; //UC5 ADDED MONTHLY WAGE

        public string EmployeeId
        {
            get { return employeeid; }
            set { employeeid = value; }
        }
        public string EmployeeName
        {
            get { return employeename; }
            set { employeename = value; }
        }
        public double EmployeeDailyWage
        {
            get { return employeedailywage; }
            set { employeedailywage = value; }
        }
        public long EmployeePhoneNumber
        {
            get { return employeephonenumber; }
            set { employeephonenumber = value; }
        }

        public string EmployeeAttendance
        {
            get { return employeeattendance; }
            set { employeeattendance = value; }
        }

        public bool IsPartTime
        {
            get { return isparttime; }
            set { isparttime = value; }
        }

        public double EmployeeMonthlyWage
        {
            get { return employeemonthlywage; }
            set { employeemonthlywage = value; }   // UC5 ADDED MONTHLY WAGE
        }

        public override string? ToString()
        {
            if (isparttime)
                return "----PART TIME EMPLOYEE----\n\nEmployee ID : " + employeeid + "\nEmployee Name : " + employeename + "\nEmployee Salary/Wage : " + employeedailywage + "\nEmployee Monthly Wage :"+employeemonthlywage+ "\nEmployee  Phone Number : " + employeephonenumber + "\nEmployee Attendance : " + employeeattendance;
            else
                return "----FULL TIME EMPLOYEE----\n\nEmployee ID : " + employeeid + "\nEmployee Name : " + employeename + "\nEmployee Salary/Wage : " + employeedailywage + "\nEmployee Monthly Wage :"+employeedailywage+ "\n Employee Phone Number : " + employeephonenumber + "\nEmployee Attendance : " + employeeattendance;
        }
    }
}