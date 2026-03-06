namespace AddressBook
{
    public interface IAddressBook
    {
        AddressBook AddPerson();
        void DisplayContact();
        void EditContact();
        void DeleteContact();

        void AddAddressBook();
        void ShowAllAddressBooks();
        void SearchPersonByCityOrState();
        void SearchPersonByCity();
        void SearchPersonByState();
        void CountByCity();
        void CountByState();
        void SortByName();
        void SortByCity();
        void SortByState();
        void SortByZip();
    }
}