using System;
public class Book
{
    public string title;
    public string author;
    public double price;

    public void DisplayDetails()
    {
        Console.WriteLine("Enters Title Name:");
        title = Console.ReadLine();

        Console.WriteLine("Enters Author Name:");
        author = Console.ReadLine();

        Console.WriteLine("Enter Price:");
        price = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Book Details:");
        Console.WriteLine("Title Name:"+title);
        Console.WriteLine("Author name:"+author);
        Console.WriteLine("Price:"+price);
    }
}


public class HandleBook
{
    static void Main(string[] args)
    {
        Book book = new Book();
        book.DisplayDetails();
    }
}