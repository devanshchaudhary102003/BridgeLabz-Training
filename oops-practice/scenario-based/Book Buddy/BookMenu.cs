using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BookBuddy
{
    internal class BookMenu
    {
        IBook Bookutility = new BookUtilityImpl();

        public void Menu()
        {
            int choice;

            do
            {
                Console.WriteLine("\n📚 BookBuddy – Digital Bookshelf");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Sort Books");
                Console.WriteLine("3. Search by Author");
                Console.WriteLine("4. Display All Books");
                Console.WriteLine("5. Exit");

                Console.WriteLine("Enter Your Choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Bookutility.AddBook();
                        break;

                    case 2:
                        Bookutility.SortBooksAlphabetically(); 
                        break;
                    case 3:
                        Bookutility.SearchByAuthor();
                        break;

                    case 4:
                        Bookutility.DisplayAllBooks();
                        break;

                    case 5:
                        Console.WriteLine("Thank you for using BookBuddy!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            } while (choice != 5);
        }
    }
}
