using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal class AddressBookMain
    {
        static void Main(string[] args)
        {
            AddressBookMenu menu = new AddressBookMenu();
            menu.Menu();
        }
    }
}
