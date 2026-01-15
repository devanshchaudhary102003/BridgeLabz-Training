using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AddressBook_System
{
    internal class AddressBookUtilityImpl:IAddressBook
    {
        private AddressBook[] addressBooks = new AddressBook[10];   //UC-5  Ability to add multiple person to Address Book

        private int count = 0;

        public void AddContact()    //UC-2  Ability to add a new Contact to Address Book
        {
            if (count == addressBooks.Length)
            {
                Console.WriteLine("Address Book is full. Cannot and More Contacts");
                return;
            }

            AddressBook contact = new AddressBook();

            Console.WriteLine("Enter First Name: ");
            contact.firstName = Console.ReadLine();

            for (int i = 0; i < count; i++)      //UC-6 Refactor to add multiple Address Book to the System.Each Address Book has a unique Name
            {
                if (addressBooks[i] != null && addressBooks[i].firstName.Equals(contact.firstName, StringComparison.OrdinalIgnoreCase)) //UC-7 Ability to ensure there is no Duplicate Entry of the same Person in a particular Address Book - Duplicate
                {
                    Console.WriteLine("Contact Details Already Exists");
                    return;
                }
            }
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

                Console.WriteLine(contact);
                Console.WriteLine("\nContact added Successfully!");
            }
        

        public void EditContact()   //UC-3  Ability to edit existing contact person using their name
        {
            if(count == 0)
            {
                Console.WriteLine("No Contact Available to Edit");
                return;
            }

            Console.WriteLine("Enter First Name Of Contact to Edit");
            string name = Console.ReadLine();

            for(int i = 0; i < count; i++)
            {
                if (addressBooks[i] != null && addressBooks[i].firstName.Equals(name, StringComparison.OrdinalIgnoreCase)){
                    int choice;

                    do
                    {
                        Console.WriteLine("------- Edit Contact Menu --------");
                        Console.WriteLine("1. First Name");
                        Console.WriteLine("2. Last name");
                        Console.WriteLine("3. Address");
                        Console.WriteLine("4. City");
                        Console.WriteLine("5. State");
                        Console.WriteLine("6. Zip");
                        Console.WriteLine("7. Phone");
                        Console.WriteLine("8. Email");
                        Console.WriteLine("0. Exit Edit");

                        Console.WriteLine("Choose Field To Edit");

                        choice = Convert.ToInt32(Console.ReadLine());

                        switch(choice)
                        {
                            case 1:
                                Console.WriteLine("Enter New First Name: ");
                                addressBooks[i].firstName = Console.ReadLine();
                                break;

                            case 2:
                                Console.WriteLine("Enter New Last Name: ");
                                addressBooks[i].lastName = Console.ReadLine();
                                break;

                            case 3:
                                Console.WriteLine("Enter New Address: ");
                                addressBooks[i].address = Console.ReadLine();
                                break;

                            case 4:
                                Console.Write("Enter New City: ");
                                addressBooks[i].city = Console.ReadLine();
                                break;

                            case 5:
                                Console.Write("Enter New State: ");
                                addressBooks[i].state = Console.ReadLine();
                                break;

                            case 6:
                                Console.Write("Enter New Zip: ");
                                addressBooks[i].zip = Console.ReadLine();
                                break;

                            case 7:
                                Console.Write("Enter New Phone: ");
                                addressBooks[i].phonenumber = Console.ReadLine();
                                break;

                            case 8:
                                Console.Write("Enter New Email: ");
                                addressBooks[i].email = Console.ReadLine();
                                break;

                            case 0:
                                Console.WriteLine("Exiting Edit Menu...");
                                Console.WriteLine(addressBooks[i]);
                                break;

                            default:
                                Console.WriteLine("Invalid choice!");
                                break;
                        }
                    } while (choice != 0);

                    Console.WriteLine("Contact Updated Successfully!");
                    return;
                }
            }
            Console.WriteLine("Contact Not Found");
        }

        public void DeleteContact() //UC-4  Ability to delete a person using person's name - Use Console to delete a person
        {
            if(count == 0)
            {
                Console.WriteLine("No Contact to delete");
                return;
            }

            Console.WriteLine("Enter First Name of Contact to delete");
            string name = Console.ReadLine();

            for (int i = 0; i < count; i++)
            {
                if (addressBooks[i] != null && addressBooks[i].firstName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    for (int j = i; j < count; j++)
                    {
                        addressBooks[j] = addressBooks[j + 1];
                    }
                    Console.WriteLine("Contact details: " + addressBooks[i]);
                    Console.WriteLine("Delete Contact Successfully");
                    break;
                }
                else
                {
                    Console.WriteLine("No name found");
                    return;
                }
            }
        }

        public void SearchPersonByCityOrPerson()    //UC-8  Ability to search Person in a City or State across the multiple Address Book
        {
            Console.WriteLine("Enter City or State: ");
            string location = Console.ReadLine();

            bool found = false;
            int PersonCount = 0;                    //UC-10 Ability to get number of contact persons i.e.count by City or State - Search Result

            for (int i = 0; i < count; i++)
            {
                if(addressBooks[i] != null && ((addressBooks[i].city.Equals(location, StringComparison.OrdinalIgnoreCase)) || (addressBooks[i].state.Equals(location, StringComparison.OrdinalIgnoreCase))))    //UC-9  Ability to view Persons by City or State
                {
                    Console.WriteLine(addressBooks[i]);
                    found = true;
                    PersonCount++;                  //UC-10 Ability to get number of contact persons i.e.count by City or State - Search Result
                }

            }
            if (!found)
            {
                Console.WriteLine("Contact Not Found At That City Or State");
            }
            else
            {
                Console.WriteLine("Total Contacts in City Or State: "+PersonCount);     //UC-10 Ability to get number of contact persons i.e.count by City or State - Search Result
            }
        }

        public void DisplayDetails()
        {
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine("----------------------- Display Details -------------------------");
                Console.WriteLine(addressBooks[i]);
            }
        }
    }
}
