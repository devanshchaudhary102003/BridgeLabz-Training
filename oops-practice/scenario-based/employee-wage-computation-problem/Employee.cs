using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class Employee
    {
        private string employeeid {  get; set; }
        private string employeename { get; set; }
        private string employeesalary { get; set; }
        private long employeephonenumber { get; set; }

        private string employeeattendance { get; set; } // UC1 Employee Attendance Check

        public string EmployeeId
        {
            get { 
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

        public string EmployeeSalary
        {
            get
            {
                return employeesalary;
            }
            set
            {
                employeesalary = value;
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

        public override string? ToString()
        {
            return "Employee ID: " + employeeid + "\nEmployee Name: " + employeename + "\nEmployee Salary : " + employeesalary + "\nEmployee Phone Number : " + employeephonenumber +"\nEmployee Attendance : " +EmployeeAttendance;
        }
    }
}
