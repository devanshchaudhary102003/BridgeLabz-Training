using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal class AddressBookMenu
    {
        IAddressBook Contact = new AddressBookUtilityImpl();

        public void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("\n===== ADDRESS BOOK MENU =====");
                Console.WriteLine("1. Add Contact");    //UC-2
                Console.WriteLine("2. Edit Contact");   //UC-3
                Console.WriteLine("3. Delete Contact"); //UC-4
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Contact.AddContact();
                        break;

                    case 2:
                        Contact.EditContact();
                        break;

                    case 3:
                        Contact.DeleteContact();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            } while (choice != 0);
        }
    }
}
