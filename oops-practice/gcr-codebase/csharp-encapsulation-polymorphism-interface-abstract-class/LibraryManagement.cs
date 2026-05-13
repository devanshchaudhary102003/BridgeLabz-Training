using System;
interface IReservable
{
    void ReserveItem(string borrowerName);
    bool CheckAvailability();
}
abstract class LibraryItem : IReservable
{
    private int itemId;
    private string title;
    private string author;

    public int ItemId
    {
        get
        {
            return itemId;
        }
        set
        {
            itemId = value;
        }
    }

    public string Title
    {
        get
        {
            return title;
        }
        set
        {
            title = value;
        }
    }

    public string Author
    {
        get
        {
            return author;
        }
        set
        {
            author = value;
        }
    }

    public abstract int GetLoanDuration();

    public void GetItemDetails()
    {
        Console.WriteLine("Item Id: "+itemId);
        Console.WriteLine("Title of the book: "+title);
        Console.WriteLine("Author of the book: "+author);
        Console.WriteLine("Loan Duration: "+GetLoanDuration()+" days ");
        Console.WriteLine("Status: " + (isAvailable ? "Available" : "Not Available"));
    }
    // Encapsulated borrower data
    private string borrowerName;
    private bool isAvailable = true;

    //Interface Methods
    public virtual void ReserveItem(string name)
    {
        if (isAvailable)
        {
            borrowerName = name;
            isAvailable = false;
            Console.WriteLine("Item reserved by "+borrowerName);
        }
        else
        {
            Console.WriteLine("Item is not available");
        }
    }

    public virtual bool CheckAvailability()
    {
        return isAvailable;
    }
}

class Book : LibraryItem
{
    public override int GetLoanDuration()
    {
        return 14;
    }

    public override void ReserveItem(string name)
    {
        Console.WriteLine("Book Reservation Started...");
        base.ReserveItem(name);
    }

    public override bool CheckAvailability()
    {
        return base.CheckAvailability();
    }
}

class Magazine : LibraryItem
{
    public override int GetLoanDuration()
    {
        return 7;
    }

    public override void ReserveItem(string name)
    {
        Console.WriteLine("Magazine Reservation Started...");
        base.ReserveItem(name);
    }

    public override bool CheckAvailability()
    {
        return base.CheckAvailability();
    }
}

class DVD : LibraryItem
{
    public override int GetLoanDuration()
    {
        return 3;
    }

    public override void ReserveItem(string name)
    {
        Console.WriteLine("DVD Reservation Started...");
        base.ReserveItem(name);
    }

    public override bool CheckAvailability()
    {
        return base.CheckAvailability();
    }
}
class LibraryManagement
{
    static void Main(string[] args)
    {
        LibraryItem[] libraryItem = new LibraryItem[3];

        libraryItem[0] = new Book();
        libraryItem[0].ItemId = 101;
        libraryItem[0].Title = "C# Programming";
        libraryItem[0].Author = "Microsoft";
        libraryItem[0].ReserveItem("Devansh");

        libraryItem[1] = new Magazine();
        libraryItem[1].ItemId = 102;
        libraryItem[1].Title = "Tech World";
        libraryItem[1].Author = "Editor";
        libraryItem[1].ReserveItem("Rajputana");

        libraryItem[2] = new DVD();
        libraryItem[2].ItemId = 103;
        libraryItem[2].Title = "Intersteller";
        libraryItem[2].Author = "Rohit";
        libraryItem[2].ReserveItem("Sundar pichai");

        for(int i = 0; i < libraryItem.Length; i++)
        {
            Console.WriteLine("----------------------------------------");
            libraryItem[i].GetItemDetails();
        }
    }
}