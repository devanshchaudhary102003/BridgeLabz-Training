using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AddressBook_System
{
    internal class AddressBookUtilityImpl : IAddressBook
    {
        // ✅ Array -> List (UC-5 refactor style)
        private readonly List<AddressBook> addressBooks = new List<AddressBook>();

        public void AddContact() // UC-2
        {
            AddressBook contact = new AddressBook();

            Console.WriteLine("Enter First Name: ");
            contact.firstName = Console.ReadLine();

            // UC-7 Duplicate check (same)
            for (int i = 0; i < addressBooks.Count; i++)
            {
                if (addressBooks[i] != null &&
                    addressBooks[i].firstName.Equals(contact.firstName, StringComparison.OrdinalIgnoreCase))
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

            addressBooks.Add(contact);

            Console.WriteLine(contact);
            Console.WriteLine("\nContact added Successfully!");
        }

        public void EditContact() // UC-3
        {
            if (addressBooks.Count == 0)
            {
                Console.WriteLine("No Contact Available to Edit");
                return;
            }

            Console.WriteLine("Enter First Name Of Contact to Edit");
            string name = Console.ReadLine();

            for (int i = 0; i < addressBooks.Count; i++)
            {
                if (addressBooks[i] != null &&
                    addressBooks[i].firstName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
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

                        bool ok = int.TryParse(Console.ReadLine(), out choice);
                        if (!ok)
                        {
                            Console.WriteLine("Invalid input. Enter a number.");
                            continue;
                        }

                        switch (choice)
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

        public void DeleteContact() // UC-4
        {
            if (addressBooks.Count == 0)
            {
                Console.WriteLine("No Contact to delete");
                return;
            }

            Console.WriteLine("Enter First Name of Contact to delete");
            string name = Console.ReadLine();

            for (int i = 0; i < addressBooks.Count; i++)
            {
                if (addressBooks[i] != null &&
                    addressBooks[i].firstName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Contact details: " + addressBooks[i]);
                    addressBooks.RemoveAt(i); // ✅ List way (safe)
                    Console.WriteLine("Delete Contact Successfully");
                    return;
                }
            }

            Console.WriteLine("No name found");
        }

        public void SearchPersonByCityOrPerson() // UC-8, UC-9, UC-10
        {
            Console.WriteLine("Enter City or State: ");
            string location = Console.ReadLine();

            bool found = false;
            int personCount = 0;

            for (int i = 0; i < addressBooks.Count; i++)
            {
                if (addressBooks[i] != null &&
                    (addressBooks[i].city.Equals(location, StringComparison.OrdinalIgnoreCase) ||
                     addressBooks[i].state.Equals(location, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine(addressBooks[i]);
                    found = true;
                    personCount++;
                }
            }

            if (!found)
                Console.WriteLine("Contact Not Found At That City Or State");
            else
                Console.WriteLine("Total Contacts in City Or State: " + personCount);
        }

        public void SortEntriesByName() // UC-11
        {
            if (addressBooks.Count == 0)
            {
                Console.WriteLine("No Contacts Available To Sort");
                return;
            }

            // ✅ same compare logic, just List sort
            addressBooks.Sort((a, b) =>
                string.Compare(a.firstName, b.firstName, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("--------- Contact Sorted By Name -------------");
            for (int i = 0; i < addressBooks.Count; i++)
            {
                Console.WriteLine(addressBooks[i]);
                Console.WriteLine("----------------------------------");
            }
        }

        public void SortEntriesByCity()
        {
            if(addressBooks.Count == 0)
            {
                Console.WriteLine("No contacts available to sort");
                return;
            }

            addressBooks.Sort((a,b) =>
                string.Compare(a.city, b.city, StringComparison.OrdinalIgnoreCase));

            for(int i = 0; i < addressBooks.Count; i++)
            {
                Console.WriteLine(addressBooks[i]);
                Console.WriteLine("-----------------------------------");
            }
        }

        public void SortEntriesByState()
        {
            if(addressBooks.Count == 0)
            {
                Console.WriteLine("No contacts available to sort");
                return;
            }

            addressBooks.Sort((a,b) => string.Compare(a.state, b.state, StringComparison.OrdinalIgnoreCase));

            for(int i = 0; i < addressBooks.Count; i++)
            {
                Console.WriteLine(addressBooks[i]);
                Console.WriteLine("-----------------------------------");
            }
        }

        public void SortEntriesByZip()
        {
            if(addressBooks.Count == 0)
            {
                Console.WriteLine("No Contacts available to sort");
                return;
            }

            addressBooks.Sort((a,b) => string.Compare(a.zip,b.zip,StringComparison.OrdinalIgnoreCase));

            for(int i = 0; i < addressBooks.Count; i++)
            {
                Console.WriteLine(addressBooks[i]);
                Console.WriteLine("----------------------------------------");
            }
        }

        public void DisplayDetails()
        {
            if (addressBooks.Count == 0)
            {
                Console.WriteLine("No contacts to display.");
                return;
            }

            Console.WriteLine("----------------------- Display Details -------------------------");
            for (int i = 0; i < addressBooks.Count; i++)
            {
                Console.WriteLine(addressBooks[i]);
                Console.WriteLine("---------------------------------------------------------------");
            }
        }
    }
}
