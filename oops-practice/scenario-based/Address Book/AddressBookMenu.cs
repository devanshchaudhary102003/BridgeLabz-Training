using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                Console.WriteLine("1. Add Contact");                         //UC-2  Ability to add a new Contact to Address Book
                Console.WriteLine("2. Edit Contact");                       //UC-3  Ability to edit existing contact person using their name
                Console.WriteLine("3. Delete Contact");                    //UC-4   Ability to delete a person using person's name - Use Console to delete a person
                Console.WriteLine("4. Search Contact By City And State"); // UC-8   Ability to search Person in a City or State across the multiple Address Book
                Console.WriteLine("5 Sort The Entries By Name");         // UC-11   Ability to sort the entries in the address book alphabetically by Person’s name
                Console.WriteLine("6. Display Details");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Contact.AddContact();                          //UC-2  Ability to add a new Contact to Address Book
                        break;

                    case 2:
                        Contact.EditContact();                        //UC-3  Ability to edit existing contact person using their name
                        break;

                    case 3:
                        Contact.DeleteContact();                      //UC-4   Ability to delete a person using person's name - Use Console to delete a person
                        break;

                    case 4:
                        Contact.SearchPersonByCityOrPerson();        // UC-8   Ability to search Person in a City or State across the multiple Address Book
                        break;

                    case 5:
                        Contact.SortEntriesByName();                // UC-11   Ability to sort the entries in the address book alphabetically by Person’s name
                        break;

                    case 6:
                        Contact.DisplayDetails();
                        break;


                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            } while (choice != 0);
        }
    }
}
