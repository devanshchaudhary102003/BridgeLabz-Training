using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal class AddressBookUtilityImpl:IAddressBook
    {
        private AddressBook[] addressBooks = new AddressBook[10];

        private int count = 0;

        public void AddContact()
        {
            if(count == addressBooks.Length)
            {
                Console.WriteLine("Address Book is full. Cannot and More Contacts");
                return;
            }

            AddressBook contact = new AddressBook();

            Console.WriteLine("Enter First Name: ");
            contact.firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name: ");
            contact.lastName = Console.ReadLine();

            Console.Write("Enter Address: ");
            contact.address = Console.ReadLine();

            Console.Write("Enter City: ");
            contact.city = Console.ReadLine();

            Console.Write("Enter State: ");
            contact.state = Console.ReadLine();

            Console.Write("Enter Zip: ");
            contact.zip = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            contact.phonenumber = Console.ReadLine();

            Console.Write("Enter Email: ");
            contact.email = Console.ReadLine();

            addressBooks[count] = contact;
            count++;

            Console.WriteLine("\nContact added Successfully!");
        }

    }
}
