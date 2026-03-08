using System;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Main entry point of Address Book application
            // Control is transferred to AddressBookMenu class
            AddressBookMenu Menu = new AddressBookMenu();
            await Menu.MenuAsync();
        }
    }
}