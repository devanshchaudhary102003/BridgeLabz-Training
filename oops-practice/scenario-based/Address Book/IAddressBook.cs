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
        void SearchPersonByCityOrPerson();    //UC-8  Ability to search Person in a City or State across the multiple Address Book
        void SortEntriesByName();              //UC-11 Ability to sort the entries in the address book alphabetically by Person’s name
    }
}
