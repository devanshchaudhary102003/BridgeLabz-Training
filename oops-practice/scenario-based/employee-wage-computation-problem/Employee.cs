using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
     class Employee
     {
        private string employeeid;
        private string employeename;
        private long employeephonenumber;

        private string employeeattendance; // UC1 Employee Attendance Check

        public double employeedailywage;//  UC2 Adding Daily Wage

        public string EmployeeId
        {
            get
            {
                return employeeid;
            }
            set
            {
                employeeid = value;
            }
        }
        public string EmployeeName
        {
            get
            {
                return employeename;
            }
            set
            {
                employeename = value;
            }
        }

        public long EmployeePhoneNumber
        {
            get
            {
                return employeephonenumber;
            }
            set
            {
                employeephonenumber = value;
            }
        }

        public string EmployeeAttendance
        {
            get
            {
                return employeeattendance;
            }
            set
            {
                employeeattendance = value;
            }
        }

        public double EmployeeDailyWage
        {
            get
            {
                return employeedailywage;
            }
            set
            {
                employeedailywage = value;
            }
        }

        public override string? ToString()
        {
            return "Employee ID: " + employeeid + "\nEmployee Name: " + employeename + "\nEmployee Wage : " + employeedailywage + "\nEmployee Phone Number : " + employeephonenumber +"\nEmployee Attendance : " +EmployeeAttendance;
        }
    }
}
