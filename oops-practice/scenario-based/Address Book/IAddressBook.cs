using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal interface IAddressBook
    {
        void AddContact();  //UC-2  Ability to add a new Contact to Address Book
        void EditContact(); //UC-3  Ability to edit existing contact person using their name
        void DeleteContact();   //UC-4  Ability to delete a person using person's name - Use Console to delete a person
        void DisplayDetails();
    }
}
