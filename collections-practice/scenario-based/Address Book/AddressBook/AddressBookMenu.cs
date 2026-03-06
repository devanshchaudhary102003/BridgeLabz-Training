namespace AddressBook
{
    public class AddressBookMenu
    {
        public void Menu()
        {
            IAddressBook bookutility = new AddressBookUtility();

            while(true)
            {
                Console.WriteLine("\n================= WELCOME TO ADDRESS BOOK ==================\n");
                Console.WriteLine("\n1. Add Contact");
                Console.WriteLine("\n2. Display Contact Details");
                Console.WriteLine("\n3. Edit Contact Details");
                Console.WriteLine("\n4. Delete Contact Details");
                Console.WriteLine("\n5. Add Address Book");
                Console.WriteLine("\n6. Show All Address Book");
                Console.WriteLine("\n7. Search Person By City Or State");
                Console.WriteLine("\n8. Search Person By City");
                Console.WriteLine("\n9. Search Person By State");
                Console.WriteLine("\n10. Count Person By City");
                Console.WriteLine("\n11. Count Person By State");
                Console.WriteLine("\n12. Sort By Name");
                Console.WriteLine("\n13. Sort By City");
                Console.WriteLine("\n14. Sort By State");
                Console.WriteLine("\n15. Sort By Zip");
                Console.WriteLine("\n16. Exit");

                Console.WriteLine("\nEnter the choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        bookutility.AddPerson();
                        break;

                    case 2:
                        bookutility.DisplayContact();
                        break;

                    case 3:
                        bookutility.EditContact();
                        break; 

                    case 4:
                        bookutility.DeleteContact();
                        break; 

                    case 5:
                        bookutility.AddAddressBook();
                        break;  

                    case 6:
                        bookutility.ShowAllAddressBooks();
                        break;  

                    case 7:
                        bookutility.SearchPersonByCityOrState();
                        break;

                    case 8:
                        bookutility.SearchPersonByCity();
                        break;  

                    case 9:
                        bookutility.SearchPersonByState();
                        break;

                    case 10:
                        bookutility.CountByCity();
                        break;  

                    case 11:
                        bookutility.CountByStates();
                        break;

                    case 12:
                        bookutility.SortByName();
                        break;

                    case 13:
                        bookutility.SortByCity();
                        break;  

                    case 14:
                        bookutility.SortByState();
                        break;

                    case 15:
                        bookutility.SortByZip();
                        break;

                    case 16:
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