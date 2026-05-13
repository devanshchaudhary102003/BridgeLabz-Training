using System;
public class Book
{
    public string Title;
    public string Author;
    public int Price;

    //Default Constructor
    public Book()
    {
        Title = "John Bull";
        Author = "Meena";
        Price = 45000;
    }

    //Parameterized Constructor
    public Book(string title, string author, int price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("----------------Book Details:----------------");
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Price: " + Price);
        Console.WriteLine();
    }
}
public class Books
{
    
    static void Main(string[] args)
    {
        Book defaultBook = new Book();
        defaultBook.DisplayDetails();

        Book parameterizedBook = new Book();
        parameterizedBook.DisplayDetails();
    }
}