using System;
class Book
{
    public static string LibraryName = "Central Library";

    public string TitleName;
    public string AuthorName;
    public readonly int ISBN;

    public Book(string TitleName, string AuthorName, int ISBN)
    {
        this.TitleName = TitleName;
        this.AuthorName = AuthorName;
        this.ISBN = ISBN;
    }
    public static void DisplayLibraryName()
    {
        Console.WriteLine("Library Name:"+LibraryName);
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Title Name:"+TitleName);
        Console.WriteLine("Author Name:"+AuthorName);
        Console.WriteLine("ISBN:"+ISBN);
    }
}
class LibraryManagementSystem
{
    static void Main(string[] args)
    {
        Book b1 = new Book("C# Programming","Devansh",123456);
        Book b2 = new Book("Java Programming","Dev",987654);

        if(b1 is Book)
        {
            Console.WriteLine("b1 is a book object");
            b1.DisplayDetails();
            Book.DisplayLibraryName();
        }

        Console.WriteLine();

        if(b2 is Book)
        {
            Console.WriteLine("b2 is a book object");
            b2.DisplayDetails();
            Book.DisplayLibraryName();
        }

        
    }
}