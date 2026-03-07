using System.Text.Json;

namespace AddressBook
{
    public class AddressBookUtility : IAddressBook
    {
        // Object used for storing single contact details
        AddressBook addressBook;

        // UC5 - Dictionary to store multiple address books with unique name
        Dictionary<string,List<AddressBook>> addressBooks = new Dictionary<string, List<AddressBook>>();

        // UC8 - Dictionary to store city wise persons
        Dictionary<string,List<AddressBook>> cityDictionary = new Dictionary<string, List<AddressBook>>();

        // UC8 - Dictionary to store state wise persons
        Dictionary<string,List<AddressBook>> stateDictionary = new Dictionary<string, List<AddressBook>>();

        // UC5 - Add new address book with unique name
        public void AddAddressBook()
        {
            Console.WriteLine("Enter Address Book: ");
            string Book = Console.ReadLine();

            // Check if address book already exists
            if (addressBooks.ContainsKey(Book))
            {
                Console.WriteLine("Book Already Exits!");
                return;
            }

            // Add new address book with empty contact list
            addressBooks.Add(Book,new List<AddressBook>());

            Console.WriteLine("Book added Successfully");
        }

        // UC1, UC4, UC6 - Add new contact to selected address book
        public AddressBook AddPerson()
        {
            Console.WriteLine("Enter Address Book: ");
            string book = Console.ReadLine();

            // Check whether address book exists
            if (!addressBooks.ContainsKey(book))
            {
                Console.WriteLine("Book is not Exits Firstly Added the Book");
                return null;
            }

            addressBook = new AddressBook();
            List<AddressBook> address = addressBooks[book];

            Console.WriteLine("Enter First Name: ");
            addressBook.firstName = Console.ReadLine();

            // UC6 - Prevent duplicate entry by checking first name in same address book
            for(int i = 0; i < address.Count; i++)
            {
                if (address[i].firstName.Equals(addressBook.firstName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Duplicate Entry Same Person Already Exists");
                    return null;
                }
            }

            Console.WriteLine("Enter Last Name: ");
            addressBook.lastName = Console.ReadLine();

            Console.WriteLine("Enter Address: ");
            addressBook.address = Console.ReadLine();

            Console.WriteLine("Enter City: ");
            addressBook.city = Console.ReadLine();

            Console.WriteLine("Enter State: ");
            addressBook.state = Console.ReadLine();

            Console.WriteLine("Enter Zip: ");
            addressBook.zip = Console.ReadLine();

            Console.WriteLine("Enter Phone Number: ");
            addressBook.phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Email Id: ");
            addressBook.email = Console.ReadLine();

            // Add contact to selected address book
            addressBooks[book].Add(addressBook);

            // UC8 - Maintain city wise dictionary
            if (!cityDictionary.ContainsKey(addressBook.city))
            {
                cityDictionary[addressBook.city] = new List<AddressBook>();
            }
            cityDictionary[addressBook.city].Add(addressBook);

            // UC8 - Maintain state wise dictionary
            if (!stateDictionary.ContainsKey(addressBook.state))
            {
                stateDictionary[addressBook.state] = new List<AddressBook>();
            }
            stateDictionary[addressBook.state].Add(addressBook);

            Console.WriteLine("Contact Added Successfully");
            return addressBook;
        }

        // UC2 - Edit existing contact by first name
        public void EditContact()
        {
            Console.WriteLine("Enter Book Name: ");
            string Book = Console.ReadLine();

            if (!addressBooks.ContainsKey(Book))
            {
                Console.WriteLine("Book is not Exits Firstly Added the Book");
                return;
            }

            Console.WriteLine("Enter First Name to Search: ");
            string SearchName = Console.ReadLine();

            List<AddressBook> address = addressBooks[Book];
            bool found = false;

            for(int i = 0; i < address.Count; i++)
            {
                AddressBook addr = address[i];

                // Search contact by first name
                if(SearchName == addr.firstName)
                {
                    found = true;
                    while (true)
                    {
                        // Edit menu for updating required field
                        Console.WriteLine("1. First Name");
                        Console.WriteLine("2. Last Name");
                        Console.WriteLine("3. Address");
                        Console.WriteLine("4. City");
                        Console.WriteLine("5. State");
                        Console.WriteLine("6. Zip");
                        Console.WriteLine("7. Phone Number");
                        Console.WriteLine("8. Email");
                        Console.WriteLine("9. Exit Edit Menu");

                        Console.WriteLine("Enter the Choice: ");
                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch(choice)
                        {
                            case 1:
                                Console.WriteLine("Enter First Name for Edit: ");
                                address[i].firstName = Console.ReadLine();
                                break;

                            case 2:
                                Console.WriteLine("Enter Last Name for Edit: ");
                                address[i].lastName = Console.ReadLine();
                                break;

                            case 3:
                                Console.WriteLine("Enter Address for Edit: ");
                                address[i].address = Console.ReadLine();
                                break;

                            case 4:
                                Console.WriteLine("Enter City for Edit: ");
                                address[i].city = Console.ReadLine();
                                break;

                            case 5:
                                Console.WriteLine("Enter State for Edit: ");
                                address[i].state = Console.ReadLine();
                                break;

                            case 6:
                                Console.WriteLine("Enter zip for Edit: ");
                                address[i].zip = Console.ReadLine();
                                break;

                            case 7:
                                Console.WriteLine("Enter phone number for Edit: ");
                                address[i].phoneNumber = Console.ReadLine();
                                break;

                            case 8:
                                Console.WriteLine("Enter Email for Edit: ");
                                address[i].email = Console.ReadLine();
                                break;

                            case 9:
                                Console.WriteLine("Exit Edit Menu THANK YOU ");
                                return;

                            default:
                                Console.WriteLine("Invalid Choice!");
                                break;
                        }
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("Contact Not Found!");
            }
        }

        // UC3 - Delete contact using person's first name
        public void DeleteContact()
        {
            Console.WriteLine("Enter Book Name: ");
            string Book = Console.ReadLine();

            if (!addressBooks.ContainsKey(Book))
            {
                Console.WriteLine("Book is not Exists Firstly Added the Book");
                return;
            }

            Console.WriteLine("Enter First Name: ");
            string searchName = Console.ReadLine();

            List<AddressBook> address = addressBooks[Book];
            bool found = false;

            for(int i = 0; i < address.Count; i++)
            {
                AddressBook addr = address[i];
                
                // Match first name and delete contact
                if(searchName == addr.firstName)
                {
                    found = true;
                    address.RemoveAt(i);
                    Console.WriteLine("Contact Deleted Successfully!");
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("No Contact Found");
            }
        }

        // UC7 - Search persons by city or state across all address books
        public void SearchPersonByCityOrState()
        {
            Console.WriteLine("1. Search By City");
            Console.WriteLine("2. Search By State");

            Console.WriteLine("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter City or State for Search: ");
            string cityorstate = Console.ReadLine();

            bool found = false;

            // Traverse all address books
            foreach(var book in addressBooks)
            {
                string BookName = book.Key;
                List<AddressBook> address = book.Value;

                for(int i = 0; i < address.Count; i++)
                {
                    if(choice == 1)
                    {
                        // Search contact by city
                        if(address[i].city != null && address[i].city.Equals(cityorstate, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            Console.WriteLine($"[{BookName}] {address[i]}");
                        }
                    }
                    else if(choice == 2)
                    {
                        // Search contact by state
                        if(address[i].state != null && address[i].state.Equals(cityorstate, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            Console.WriteLine($"[{BookName}] {address[i]}");
                        }
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("No contact found in given city or state");
            }
        }

        // UC8 - View persons by city using city dictionary
        public void SearchPersonByCity()
        {
            Console.WriteLine("Enter Search city: ");
            string searchCity = Console.ReadLine();

            if (!cityDictionary.ContainsKey(searchCity))
            {
                Console.WriteLine("Person Not Found for given city");
                return;
            } 

            List<AddressBook> address = cityDictionary[searchCity];
            foreach(var c in address)
            {
                Console.WriteLine(c);
            }
        }

        // UC8 - View persons by state using state dictionary
        public void SearchPersonByState()
        {
            Console.WriteLine("Enter Search State: ");
            string searchState = Console.ReadLine();

            if (!stateDictionary.ContainsKey(searchState))
            {
                Console.WriteLine("No Pearson Found at given State");
                return;
            }

            List<AddressBook> address = stateDictionary[searchState];
            foreach(var c in address)
            {
                Console.WriteLine(c);
            }
        }

        // UC9 - Count persons in a given city
        public void CountByCity()
        {
            Console.WriteLine("Enter the city: ");
            string city = Console.ReadLine();

            if (cityDictionary.ContainsKey(city))
            {
                List<AddressBook> persons = cityDictionary[city];

                Console.WriteLine($"Total Persons in {city}: {persons.Count}");

                foreach(AddressBook person in persons)
                {
                    Console.WriteLine("First Name: "+person.firstName);
                    Console.WriteLine("Last Name: "+person.lastName);
                    Console.WriteLine("Address: "+person.address);
                    Console.WriteLine("City: "+person.city);
                    Console.WriteLine("State: "+person.state);
                    Console.WriteLine("Zip: "+person.zip);
                    Console.WriteLine("Phone Number: "+person.phoneNumber);
                    Console.WriteLine("-------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No Contact found in this city");
            }
        }

        // UC9 - Count persons in a given state
        public void CountByStates()
        {
            Console.WriteLine("Enter the state: ");
            string state = Console.ReadLine();

            if (stateDictionary.ContainsKey(state))
            {
                List<AddressBook> persons = stateDictionary[state];

                Console.WriteLine($"Total Persons in {state}: {persons.Count}");

                foreach(AddressBook person in persons)
                {
                    Console.WriteLine("First Name: "+person.firstName);
                    Console.WriteLine("Last Name: "+person.lastName);
                    Console.WriteLine("Address: "+person.address);
                    Console.WriteLine("City: "+person.city);
                    Console.WriteLine("State: "+person.state);
                    Console.WriteLine("Zip: "+person.zip);
                    Console.WriteLine("Phone Number: "+person.phoneNumber);
                    Console.WriteLine("-------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No Contact found in this state");
            }
        }

        // UC10 - Sort contacts alphabetically by name
        public void SortByName()
        {
            Console.WriteLine("Enter Address Book Name: ");
            string book = Console.ReadLine();

            if (!addressBooks.ContainsKey(book))
            {
                Console.WriteLine("Book not found");
                return;
            }

            List<AddressBook> person = addressBooks[book];

            if(person.Count == 0)
            {
                Console.WriteLine("No constact to sort");
                return;
            }

            // Sorting contacts alphabetically
            person.Sort((a,b) => a.firstName.CompareTo(b.lastName));

            foreach(var p in person)
            {
                Console.WriteLine(p);
            }
        }

        // UC11 - Sort contacts by city
        public void SortByCity()
        {
            Console.WriteLine("Enter Address Book Name: ");
            string book = Console.ReadLine();

            if (!addressBooks.ContainsKey(book))
            {
                Console.WriteLine("Book not found");
                return;
            }

            List<AddressBook> persons = addressBooks[book];

            if(persons.Count == 0)
            {
                Console.WriteLine("no constact to sort");
                return;
            }

            // Sorting by city name
            persons.Sort((a,b) => a.city.CompareTo(b.city));

            foreach(var person in persons)
            {
                Console.WriteLine(person);
            }
        }

        // UC11 - Sort contacts by state
        public void SortByState()
        {
            Console.WriteLine("Enter Address Book Name: ");
            string book = Console.ReadLine();

            if (!addressBooks.ContainsKey(book))
            {
                Console.WriteLine("Book not found");
                return;
            }

            List<AddressBook> persons = addressBooks[book];

            if(persons.Count == 0)
            {
                Console.WriteLine("no constact to sort");
                return;
            }

            // Sorting by state name
            persons.Sort((a,b) => a.state.CompareTo(b.state));

            foreach(var person in persons)
            {
                Console.WriteLine(person);
            }
        }

        // UC11 - Sort contacts by zip
        public void SortByZip()
        {
            Console.WriteLine("Enter Address Book Name: ");
            string book = Console.ReadLine();

            if (!addressBooks.ContainsKey(book))
            {
                Console.WriteLine("Book not found");
                return;
            }

            List<AddressBook> persons = addressBooks[book];

            if(persons.Count == 0)
            {
                Console.WriteLine("no constact to sort");
                return;
            }

            // Sorting by zip code
            persons.Sort((a,b) => a.zip.CompareTo(b.zip));

            foreach(var person in persons)
            {
                Console.WriteLine(person);
            }
        }

        // UC13 - Write address book contacts into text file using File IO
        public void WriteAddressBookToFile()
        {
            Console.WriteLine("Enter Address Book Name: ");
            string book = Console.ReadLine();

            if (!addressBooks.ContainsKey(book))
            {
                Console.WriteLine("Book not Found");
                return;
            }

            string file = book + ".txt";
            List<AddressBook> persons = addressBooks[book];

            Console.WriteLine("Total persons: " + persons.Count);

            using(StreamWriter writer = new StreamWriter(file))
            {
                foreach(AddressBook person in persons)
                {
                    // Writing each contact into file
                    writer.WriteLine(person);
                }
            }
            Console.WriteLine("Address Book written successfully to file: "+file);
        }

        // UC13 - Read address book contacts from text file using File IO
        public void ReadAddressBookFromFile()
        {
            Console.WriteLine("Enter Address Book Name: ");
            string book = Console.ReadLine();

            string file = book + ".txt";

            if (!File.Exists(file))
            {
                Console.WriteLine("No File Found");
                return;
            }

            // Create address book if it does not exist
            if (!addressBooks.ContainsKey(book))
            {
                addressBooks[book] = new List<AddressBook>();
            }
            else
            {
                // Clear existing contacts before reading from file
                addressBooks[book].Clear();
            }

            using (StreamReader reader = new StreamReader(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Splitting line data using separator
                    string[] data = line.Split('|');

                    if (data.Length == 8)
                    {
                        AddressBook person = new AddressBook();
                        person.firstName = data[0];
                        person.lastName = data[1];
                        person.address = data[2];
                        person.city = data[3];
                        person.state = data[4];
                        person.zip = data[5];
                        person.phoneNumber = data[6];
                        person.email = data[7];

                        addressBooks[book].Add(person);

                        // Update city dictionary
                        if (!cityDictionary.ContainsKey(person.city))
                        {
                            cityDictionary[person.city] = new List<AddressBook>();
                        }
                        cityDictionary[person.city].Add(person);

                        // Update state dictionary
                        if (!stateDictionary.ContainsKey(person.state))
                        {
                            stateDictionary[person.state] = new List<AddressBook>();
                        }
                        stateDictionary[person.state].Add(person);
                    }
                }
            }

            Console.WriteLine("Address Book read successfully from file: " + file);
        }

        // UC14 - Write address book contacts into CSV File
        public void WriteAddressBookToCsv()
        {
            Console.WriteLine("Enter Address Book Name: ");
            string book = Console.ReadLine();

            if (!addressBooks.ContainsKey(book))
            {
                Console.WriteLine("Book not Found");
                return;
            }

            string CsvFile = book + ".csv";
            List<AddressBook> persons = addressBooks[book];

            using(StreamWriter writer = new StreamWriter(CsvFile))
            {
                foreach(AddressBook person in persons)
                {
                    // Writing each contact into file
                    writer.WriteLine(person);
                }
            }
            Console.WriteLine("Contacts saved to CSV Successfully");
        }

        // UC14 - Read address book contacts from CSV file
        public void ReadAddressBookFromCsv()
        {
            Console.WriteLine("Enter Address Book Name: ");
            string book = Console.ReadLine();

            if (!addressBooks.ContainsKey(book))
            {
                addressBooks[book] = new List<AddressBook>();
            }
            else
            {
                addressBooks[book].Clear();
            }

            string CsvFile = book + ".csv";

            if (!File.Exists(CsvFile))
            {
                Console.WriteLine("Csv File Not Found");
                return;
            }
            List<AddressBook> persons = addressBooks[book];

            using(StreamReader writer = new StreamReader(CsvFile))
            {
                foreach(AddressBook person in persons)
                {
                    // Reading each contact into file
                    addressBooks[book].Add(person);
                }
            }
             Console.WriteLine("Address Book read successfully from CSV file: " + CsvFile);
        }

        // UC15 - Write address book contacts into JSON File
        public void WriteAddressBookToJsonFile()
        {
            Console.WriteLine("Enter Address Book Name: ");
            string book = Console.ReadLine();

            if (!addressBooks.ContainsKey(book))
            {
                Console.WriteLine("Book Not Found");
                return;
            }

            string file = book + ".json";

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonData = JsonSerializer.Serialize(addressBooks[book],options);
            File.WriteAllText(file,jsonData);

            Console.WriteLine("Address Book written to JSON file successfully.");
        }

        // UC15 - Read address book contacts from JSON File
        public void ReadAddressBookFromJsonFile()
        {
            Console.WriteLine("Enter Address Book Name: ");
            string book = Console.ReadLine();

            string file = book + ".json";

            if (!File.Exists(file))
            {
                Console.WriteLine("JSON File Not Found");
                return;
            }

            string jsonData = File.ReadAllText(file);

            List<AddressBook> person = JsonSerializer.Deserialize<List<AddressBook>>(jsonData);

            if(person == null)
            {
                Console.WriteLine("No Data Found in JSON File");
                return;
            }

            if (addressBooks.ContainsKey(book))
            {
                addressBooks[book] = person;
            }
            else
            {
                addressBooks.Add(book,person);
            }

            Console.WriteLine("Address Book read from JSON file successfully.");
        }


        // Display all contacts of selected address book
        public void DisplayContact()
        {
            Console.WriteLine("Enter Book Name: ");
            string Book = Console.ReadLine();

            if (!addressBooks.ContainsKey(Book))
            {
                Console.WriteLine("Book is not Exits Firstly Added the Book");
                return;
            }

            List<AddressBook> address = addressBooks[Book];
            
            if(address.Count == 0)
            {
                Console.WriteLine("No contacts in this AddressBook.");
                return;
            }

            for(int i = 0; i < address.Count; i++)
            {
                Console.WriteLine(address[i]);
            }
        }

        // Display all address book names present in the system
        public void ShowAllAddressBooks()
        {
            if(addressBooks.Count == 0)
            {
                Console.WriteLine("No AddressBook Created Yet.");
                return;
            }

            foreach(var name in addressBooks.Keys)
            {
                Console.WriteLine(name);
            }
        }
    }
}