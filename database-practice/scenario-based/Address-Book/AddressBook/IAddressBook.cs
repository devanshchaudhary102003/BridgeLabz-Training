namespace AddressBook
{
    // Interface defines all operations supported by Address Book System
    public interface IAddressBook
    {
        // UC1, UC4, UC6
        AddressBook AddPerson();

        // Display all contacts of an address book
        void DisplayContact();

        // UC2 - Edit existing contact
        void EditContact();

        // UC3 - Delete contact by name
        void DeleteContact();

        // UC5 - Add multiple address books
        void AddAddressBook();

        // UC5 - Show all address books
        void ShowAllAddressBooks();

        // UC7 - Search by city or state across multiple address books
        void SearchPersonByCityOrState();

        // UC8 - View persons by city
        void SearchPersonByCity();

        // UC8 - View persons by state
        void SearchPersonByState();

        // UC9 - Count persons by city
        void CountByCity();

        // UC9 - Count persons by state
        void CountByStates();

        // UC10 - Sort by name
        void SortByName();

        // UC11 - Sort by city
        void SortByCity();

        // UC11 - Sort by state
        void SortByState();

        // UC11 - Sort by zip
        void SortByZip();

        // UC13 - Write address book to file
        void WriteAddressBookToFile();

        // UC13 - Read address book from file
        void ReadAddressBookFromFile();
        // UC14 - Write address book To CSV File
        void WriteAddressBookToCsv();
        // UC14 - Read address book from File
        void ReadAddressBookFromCsv();
        // UC15 - Write address book To JSON File
        void WriteAddressBookToJsonFile();
        // UC15 - Read address book From JSON File.
        void ReadAddressBookFromJsonFile();
        // UC16 - Add contact to JSON Server
        Task AddPersonToJsonServer();
        // UC16 - Get all contacts from JSON Server
        Task GetAllPersonsFromJsonServer();
        // UC17 - Update contacts from JSON Server
        Task UpdatePersonInJsonServerAsync(int id, AddressBook updatedPerson);
        // UC17 - Delete contacts from JSON Server
        Task DeletePersonFromJsonServerAsync(int id);

        // UC17 - Asynchronously write address book contacts to a TEXT file
        // Uses non-blocking file I/O operation
        Task WriteAddressBookToFileAsync();

        // UC17 - Asynchronously read address book contacts from a TEXT file
        // Reads file data without blocking the main thread
        Task ReadAddressBookFromFileAsync();

        // UC17 - Asynchronously write address book contacts to a CSV file
        // Uses CsvHelper library with async file operations
        Task WriteAddressToCsvFileAsync();

        // UC17 - Asynchronously read address book contacts from a CSV file
        // Retrieves CSV records asynchronously
        Task ReadAddressFromCsvFileAsync();

        // UC17 - Asynchronously serialize and write contacts to a JSON file
        // Uses JsonSerializer and async file writing
        Task WriteAddressToJsonFileAsync();

        // UC17 - Asynchronously read and deserialize contacts from a JSON file
        // Uses async file reading and JSON deserialization
        Task ReadAddressFromJsonFileAsync();
    }
}