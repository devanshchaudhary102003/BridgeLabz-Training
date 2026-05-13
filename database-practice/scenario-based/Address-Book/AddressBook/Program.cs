using System;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Connection string for the database
            string connString ="Server=localhost\\SQLEXPRESS;Database=AddressBookDB;Trusted_Connection=True;TrustServerCertificate=True";

            // Create an instance of the database data source
            IDataSource dbSourse = new DataBaseDataSource(connString);

            // Pass the database data source to the utility class
            AddressBookUtility utility = new AddressBookUtility(dbSourse);

            // Main entry point of Address Book application
            // Control is transferred to AddressBookMenu class
            AddressBookMenu Menu = new AddressBookMenu();
            await Menu.MenuAsync();
        }
    }
}