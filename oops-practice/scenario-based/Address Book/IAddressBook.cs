using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal interface IAddressBook
    {
        void AddContact();  //UC-2
        void EditContact(); //UC-3
        void DeleteContact();   //UC-4
        void DisplayDetails();
    }
}
