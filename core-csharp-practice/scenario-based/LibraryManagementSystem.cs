using System;
class LibraryManagementSystem
{
    static void Main(string[] args)
    {
        string[,] books = BookDetails();
        Menu(books);
    }
    static string[,] BookDetails()
    {
        Console.WriteLine("Enter Number of Books:");
        int n = Convert.ToInt32(Console.ReadLine());

        string[,] book = new string[n,3];

        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter The Details Of The Book:");

            Console.WriteLine("Enter title Of The Book:");
            book[i,0] = Console.ReadLine();

            Console.WriteLine("Enter author Of The Book:");
            book[i,1] = Console.ReadLine();

            Console.WriteLine("Enter status Of The Book:");
            book[i,2] = Console.ReadLine();
        }
        return book;
    }

    static void Menu(string[,] book)
    {
        int choice;

        do
        {
            Console.WriteLine("-----Library Menu------");
            Console.WriteLine("1. Display All Books");
            Console.WriteLine("2. Search Book By Title");
            Console.WriteLine("3. Checkout Book");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter Choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: 
                    DisplayBooks(book);
                    break;
                case 2:
                    SearchBook(book);
                    break;
                case 3:
                    CheckoutBook(book);
                    break;
                case 4:
                    Console.WriteLine("Exit Library System");
                    break;
            }
        }while(choice != 4);
    }

    // display all the books
    static void DisplayBooks(string[,] book)
    {
        Console.WriteLine("-------Book List---------");
        for(int i = 0; i < book.GetLength(0); i++)
        {
            Console.WriteLine("Title of Book:"+book[i,0]+",Author of the Book:"+book[i,1]+",Status:"+book[i,2]);
        }
    }

    //Search book
    static void SearchBook(string[,] book)
    {
        Console.WriteLine("Enter Title Of the Book to search:");
        string search = Console.ReadLine().ToLower();
        bool found = false;

        for(int i = 0; i < book.GetLength(0); i++)
        {
            if (book[i, 0].ToLower().Contains(search))
            {
                Console.WriteLine("Title of Book:"+book[i,0]+",Author of the Book:"+book[i,1]+",Status:"+book[i,2]);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Book not Found");
        }
    }

    //Checkout Book
    static void CheckoutBook(string[,] book)
    {
        Console.WriteLine("Enter Book Title To checkout: ");
        string title = Console.ReadLine().ToLower();
        bool found = false;

        for(int i = 0; i < book.GetLength(0); i++)
        {
            if(book[i,0].ToLower() == title)
            {
                found = true;

                if(book[i,2].ToLower() == "available")
                {
                    book[i,2] = "CheckOut";
                    Console.WriteLine("Book checked out successfully");
                }
                else
                {
                   Console.WriteLine("Book already checkout"); 
                }
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine("Book not Found.");
        }
    }
}