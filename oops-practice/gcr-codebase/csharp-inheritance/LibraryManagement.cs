using System;

class Book
{
    public string Title;
    public int PublicationYear;

    public Book(string title, int year)
    {
        Title = title;
        PublicationYear = year;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Book Title: " + Title);
        Console.WriteLine("Publication Year: " + PublicationYear);
    }
}

class Author : Book
{
    public string Name;
    public string Bio;

    public Author(string title, int year, string name, string bio)
        : base(title, year)
    {
        Name = name;
        Bio = bio;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Author Name: " + Name);
        Console.WriteLine("Author Bio: " + Bio);
    }
}

class LibraryManagement
{
    static void Main(string[] args)
    {
        Author a1 = new Author("C# Programming",2024,"Devansh Singh","Software Developer and Trainer");

        a1.DisplayInfo();
    }
}
