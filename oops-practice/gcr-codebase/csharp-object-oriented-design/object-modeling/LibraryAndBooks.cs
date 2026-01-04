using System;
class Book
{
    public string Title;
    public string Author;

    public Book(string Title,string Author)
    {
        this.Title = Title;
        this.Author = Author;
    }

    public void DisplayBookDetails()
    {
        Console.WriteLine("Title of the Book: "+Title);
        Console.WriteLine("Author of the Book: "+Author);
        Console.WriteLine();
    }
}

//Library class (Aggregates Book objects)
class Library
{
    public string LibraryName;
    private Book[] books;   //Aggregation -> A array of book objects
    private int bookCount;
    public Library(string LibraryName)
    {
        this.LibraryName = LibraryName;
        books = new Book[10];
        bookCount = 0;
    }

    public void AddBook(Book book)
    {
        if (bookCount < books.Length)
        {
            books[bookCount++] = book;
        }
        else
        {
            Console.WriteLine("Library is full!");
        }
    }

    public void DisplayLibraryBook()
    {
        Console.WriteLine("Library: "+LibraryName);
        Console.WriteLine("Books Available: ");
        Console.WriteLine("------------------------------");

        for (int i = 0; i < bookCount; i++)
        {
            books[i].DisplayBookDetails();
        }
    }
}
class LibraryAndBooks
{
    static void Main(string[] args)
    {
        // Creating Book objects(independent)
        Book b1 = new Book("C# Programming","Devansh");
        Book b2 = new Book("Java Basics","James");
        Book b3 = new Book("Python Guide","Guido");

        // Creating Library object
        Library lib1 = new Library("Central Library");
        Library lib2 = new Library("College Library");

        // Aggregation: Adding books to libraries
        lib1.AddBook(b1);
        lib1.AddBook(b2);

        lib2.AddBook(b2);//add same book in other library
        lib2.AddBook(b3);

        lib1.DisplayLibraryBook();
        lib2.DisplayLibraryBook();
    }
}