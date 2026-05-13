using System;
class Book
{
    public int ISBN;      // Accessible everywhere
    protected string TitleName;         // Accessible in the same assembly and subclasses
    private string AuthorName;           // Accessible only within the class

    public Book(int isbn,string titleName,string authorName)
    {
        ISBN = isbn;
        TitleName = titleName;
        AuthorName = authorName; 
    }

    public string GetAuthor()
    {
        return AuthorName;
    }

    public void SetAuthor(string newAuthor)
    {
        AuthorName = newAuthor;
    }

    public void SetTitle(string newTitle)
    {
        TitleName = newTitle;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("-------------- Book Details --------------");
        Console.WriteLine("ISBN number:"+ISBN);
        Console.WriteLine("Title Name:"+TitleName);
        Console.WriteLine("Author Name:"+AuthorName);
    }
}

class EBook : Book
{
    public EBook(int isbn, string titleName, string authorName): base(isbn, titleName, authorName)
    {
        
    }
    public void DisplayEBookDetails()
    {
        Console.WriteLine("--------- EBook Details -------------");
        
        //Accessible because ISBN is public
        Console.WriteLine("ISBN: "+ISBN);

        // Accessible because Title is protected
        Console.WriteLine("Title: " + TitleName);

        // Not accessible (private)
        //Console.WriteLine(Author);
    }
}

class BookLibrarySystem
{
    static void Main(string[] args)
    {
        Book book = new Book(101,"C# Programming","John Smith");
        book.DisplayDetails();

        Console.WriteLine("Author (using getter): "+ book.GetAuthor());

    
        book.SetAuthor("Devansh");
        book.DisplayDetails();

        Console.WriteLine();

        EBook ebook = new EBook(202,"Advanced C#","Alice Brown");
        ebook.DisplayEBookDetails();
        ebook.SetAuthor("Akash");
        Console.WriteLine("Author (using getter): "+ ebook.GetAuthor());
        ebook.DisplayEBookDetails();
    }
}