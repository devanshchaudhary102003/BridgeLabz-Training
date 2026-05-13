using System;

namespace AddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Main entry point of Address Book application
            // Control is transferred to AddressBookMenu class
            AddressBookMenu Menu = new AddressBookMenu();
            Menu.Menu();
        }
    }
}