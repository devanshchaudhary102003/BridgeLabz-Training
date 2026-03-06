namespace AddressBook
{
    public class AddressBookUtility : IAddressBook
    {
        AddressBook addressBook;

        Dictionary<string,List<AddressBook>> addressBooks = new Dictionary<string, List<AddressBook>>();
        Dictionary<string,List<AddressBook>> cityDictionary = new Dictionary<string, List<AddressBook>>();
        Dictionary<string,List<AddressBook>> stateDictionary = new Dictionary<string, List<AddressBook>>();

        public void AddAddressBook()
        {
            Console.WriteLine("Enter Address Book: ");
            string Book = Console.ReadLine();

            if (addressBooks.ContainsKey(Book))
            {
                Console.WriteLine("Book Already Exits!");
                return;
            }

            addressBooks.Add(Book,new List<AddressBook>());

            Console.WriteLine("Book added Successfully");

        }

        public AddressBook AddPerson()
        {
            Console.WriteLine("Enter Address Book: ");
            string book = Console.ReadLine();

            if (!addressBooks.ContainsKey(book))
            {
                Console.WriteLine("Book is not Exits Firstly Added the Book");
                return null;
            }

            addressBook = new AddressBook();
            List<AddressBook> address = addressBooks[book];

            Console.WriteLine("Enter First Name: ");
            addressBook.firstName = Console.ReadLine();

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

            addressBooks[book].Add(addressBook);

            if (!cityDictionary.ContainsKey(addressBook.city))
            {
                cityDictionary[addressBook.city] = new List<AddressBook>();
            }
            cityDictionary[addressBook.city].Add(addressBook);


            if (!stateDictionary.ContainsKey(addressBook.state))
            {
                stateDictionary[addressBook.state] = new List<AddressBook>();
            }
            stateDictionary[addressBook.state].Add(addressBook);


            Console.WriteLine("Contact Added Successfully");
            return addressBook;
        }

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

                if(SearchName == addr.firstName)
                {
                    found = true;
                    while (true)
                    {
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

        public void SearchPersonByCityOrState()
        {
            Console.WriteLine("1. Search By City");
            Console.WriteLine("2. Search By State");

            Console.WriteLine("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter City or State for Search: ");
            string cityorstate = Console.ReadLine();

            bool found = false;

            foreach(var book in addressBooks)
            {
                string BookName = book.Key;
                List<AddressBook> address = book.Value;

                for(int i = 0; i < address.Count; i++)
                {
                    if(choice == 1)
                    {
                        if(address[i].city != null && address[i].city.Equals(cityorstate, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            Console.WriteLine($"[{BookName}] {address[i]}");
                        }
                    }

                    else if(choice == 2)
                    {
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

            if(addressBooks.Count == 0)
            {
                Console.WriteLine("No constact to sort");
                return;
            }

            person.Sort((a,b) => a.firstName.CompareTo(b.lastName));

            foreach(var p in person)
            {
                Console.WriteLine(p);
            }
        }

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

            persons.Sort((a,b) => a.city.CompareTo(b.city));

            foreach(var person in persons)
            {
                Console.WriteLine(person);
            }
        }

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

            persons.Sort((a,b) => a.state.CompareTo(b.state));

            foreach(var person in persons)
            {
                Console.WriteLine(person);
            }
        }

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

            persons.Sort((a,b) => a.zip.CompareTo(b.zip));

            foreach(var person in persons)
            {
                Console.WriteLine(person);
            }
        }

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