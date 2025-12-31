using System;
public class Book
{
    public string Title;
    public string Author;
    public int Price;
    public bool Availability;

    public Book(string title,string author,int price)
    {
        Title = title;
        Author = author;
        Price = price;
        Availability = true;
    }

    public void BorrowBook()
    {
        if (Availability)
        {
            Availability = false;
            Console.WriteLine("Book Borrowed successfully");
        }
        else
        {
            Console.WriteLine("This Book is Already Borrowed ");
        }
    }

    public void DisplayDetails()
    {
        Console.WriteLine("---------- Book Details ----------");
        Console.WriteLine("Title Name:"+Title);
        Console.WriteLine("Author Name:"+Author);
        Console.WriteLine("Price Of the Book:"+Price);
        Console.WriteLine("Availabilty:"+Availability);
    }
    
}
public class LibraryBookSystem
{
    static void Main(string[] args)
    {
        Book book = new Book("C#","Devansh",5000);
        book.DisplayDetails();
        book.BorrowBook();

        book.DisplayDetails();
        book.BorrowBook();

    }
}