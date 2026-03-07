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
       
    }
}