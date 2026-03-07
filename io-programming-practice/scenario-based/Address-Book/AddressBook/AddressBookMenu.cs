namespace AddressBook
{
    public class AddressBookMenu
    {
        public void Menu()
        {
            // Interface reference used for abstraction
            IAddressBook bookutility = new AddressBookUtility();

            while(true)
            {
                // Displaying all available operations of Address Book System
                Console.WriteLine("\n================= WELCOME TO ADDRESS BOOK ==================\n");
                Console.WriteLine("\n1. Add Contact");                  // UC1, UC4, UC6
                Console.WriteLine("\n2. Display Contact Details");
                Console.WriteLine("\n3. Edit Contact Details");         // UC2
                Console.WriteLine("\n4. Delete Contact Details");       // UC3
                Console.WriteLine("\n5. Add Address Book");             // UC5
                Console.WriteLine("\n6. Show All Address Book");        // UC5
                Console.WriteLine("\n7. Search Person By City Or State"); // UC7
                Console.WriteLine("\n8. Search Person By City");        // UC8
                Console.WriteLine("\n9. Search Person By State");       // UC8
                Console.WriteLine("\n10. Count Person By City");        // UC9
                Console.WriteLine("\n11. Count Person By State");       // UC9
                Console.WriteLine("\n12. Sort By Name");                // UC10
                Console.WriteLine("\n13. Sort By City");                // UC11
                Console.WriteLine("\n14. Sort By State");               // UC11
                Console.WriteLine("\n15. Sort By Zip");                 // UC11
                Console.WriteLine("\n16. Write Address To File");       // UC13
                Console.WriteLine("\n17. Read Address From File");      // UC13 
                Console.WriteLine("\n18. Write Address To CSV File");   // UC14
                Console.WriteLine("\n19. Read Address From CSV File");  // UC14
                Console.WriteLine("\n20. Write Address To JSON File");  // UC15
                Console.WriteLine("\n21. Read Address From JSON File");  // UC15
                Console.WriteLine("\n22. Exit");

                Console.WriteLine("\nEnter the choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        // Add a new contact into a selected address book
                        bookutility.AddPerson();
                        break;

                    case 2:
                        // Display all contacts of a selected address book
                        bookutility.DisplayContact();
                        break;

                    case 3:
                        // Edit existing contact using person's first name
                        bookutility.EditContact();
                        break; 

                    case 4:
                        // Delete contact using person's first name
                        bookutility.DeleteContact();
                        break; 

                    case 5:
                        // Add a new unique address book
                        bookutility.AddAddressBook();
                        break;  

                    case 6:
                        // Show all address books available in the system
                        bookutility.ShowAllAddressBooks();
                        break;  

                    case 7:
                        // Search person by city or state across multiple address books
                        bookutility.SearchPersonByCityOrState();
                        break;

                    case 8:
                        // View all persons belonging to a city
                        bookutility.SearchPersonByCity();
                        break;  

                    case 9:
                        // View all persons belonging to a state
                        bookutility.SearchPersonByState();
                        break;

                    case 10:
                        // Count number of persons in a city
                        bookutility.CountByCity();
                        break;  

                    case 11:
                        // Count number of persons in a state
                        bookutility.CountByStates();
                        break;

                    case 12:
                        // Sort contacts alphabetically by person's name
                        bookutility.SortByName();
                        break;

                    case 13:
                        // Sort contacts by city
                        bookutility.SortByCity();
                        break;  

                    case 14:
                        // Sort contacts by state
                        bookutility.SortByState();
                        break;

                    case 15:
                        // Sort contacts by zip code
                        bookutility.SortByZip();
                        break;

                    case 16:
                        // Write address book contacts into text file using File IO
                        bookutility.WriteAddressBookToFile();
                        break;

                    case 17:
                        // Read address book contacts from text file using File IO
                        bookutility.ReadAddressBookFromFile();
                        break;

                    case 18:
                        // Write address book contacts into CSV file
                        bookutility.WriteAddressBookToCsv();
                        break;

                    case 19:
                        // Read address book contacts From CSV file
                        bookutility.ReadAddressBookFromCsv();
                        break;

                    case 20:
                        // Write address book contacts into JSON File
                        bookutility.WriteAddressBookToJsonFile();
                        break;

                    case 21:
                        // Read address book contacts From JSON File
                        bookutility.ReadAddressBookFromJsonFile();
                        break;

                    case 22:
                        Console.WriteLine("THANK YOU FOR VISITING");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break; 
                }
            }
        }
    }
}