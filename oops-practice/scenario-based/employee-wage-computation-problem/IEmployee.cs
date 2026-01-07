using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    interface IEmployee
    {
        Employee AddEmployee();
        void DisplayEmployee();
        void AttendanceCheck();
    }
}
