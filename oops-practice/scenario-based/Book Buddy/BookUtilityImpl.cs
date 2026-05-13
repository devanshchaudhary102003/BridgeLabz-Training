using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuddy
{
    internal class BookUtilityImpl:IBook
    {
        private Book[] books = new Book[50];    //fixed size array
        private int count = 0;                     //number of books stored

        public void AddBook()
        {
            if(count >= books.Length)
            {
                Console.WriteLine("Book Shelf is full!");
                return;
            }

            Console.WriteLine("Enter Book Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Author Name: ");
            string author = Console.ReadLine();

            Book book = new Book();
            book.author = author;
            book.title = title; 

            books[count] = book;
            count++;

            Console.WriteLine("Book added successfully.");
        }

        public void SortBooksAlphabetically()
        {
            for(int i = 0; i < count - 1; i++)
            {
                for(int j = i + 1; j < count; j++)
                {
                    if (string.Compare(books[i].title, books[j].title) > 0)
                    {
                        string temp = books[i].title;
                        books[i].title = books[j].title;    
                        books[j].title = temp;
                    }
                }
            }
            Console.WriteLine("Books Sorted Aplhabetically");
        }

        public void SearchByAuthor()
        {
            Console.Write("Enter Author Name to Search: ");
            string author = Console.ReadLine();

            bool found = false;

            for(int i = 0; i < count; i++)
            {

                
                if(books[i].author.Equals(author, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(books[i]);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No books found by this author.");
            }
        }

        public void DisplayAllBooks()
        {
            Console.WriteLine("\n---- Your Bookshelf -------");
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine(books[i]);
            }
        }
    }
}
