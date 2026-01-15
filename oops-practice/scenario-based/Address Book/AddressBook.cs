using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AddressBook_System
{
    internal class AddressBook  //UC-1 Ability to create a Contacts in Address Book with first and last names, address,city, state, zip, phone number and email...
    {
        private string FirstName;
        private string LastName;
        private string Address;
        private string City;
        private string State;
        private string Zip;
        private string Phonenumber;
        private string Email;

        public string firstName
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        public string lastName
        {
            get { return LastName; }
            set { LastName = value; }
        }

        public string address
        {
            get { return Address; }
            set { Address = value; }
        }

        public string city
        {
            get { return City; }
            set { City = value; }
        }

        public string state
        {
            get { return State; }
            set { State = value; }
        }

        public string zip
        {
            get { return Zip; }
            set {  Zip = value; }
        }

        public string phonenumber
        {
            get { return Phonenumber; }
            set { Phonenumber = value; }
        }

        public string email
        {
            get { return Email; }
            set { Email = value; }  
        }

        public override string? ToString()
        {
            Console.WriteLine("Contact Details: ");
            return "\nFirst Name: " + firstName + " \nLastName: " + lastName + " \nAddress: " + address + " \nCity: " + city + " \nState: " + state + " \nZip: " + zip + " \nPhone Number: " + phonenumber + " \nEmail Address: " + email;
        }
    }
}
