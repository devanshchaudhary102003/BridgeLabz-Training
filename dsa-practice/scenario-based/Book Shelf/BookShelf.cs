using System;
//---------------- Book Class ------------------
class Book
{
    public string Title;
    public string Author;

    public Book(string title,string author)
    {
        Title = title;
        Author = author;
    }
}

//----------------- Book Node ---------------------
class BookNode
{
    public Book Data;
    public BookNode Next;

    public BookNode(Book book)
    {
        Data = book;
        Next = null;
    }
}

//------------------ Linked List -------------------
class BookLinkedList
{
    private BookNode head;

    //============= ADD BOOK =============
    public void AddBook(Book book)
    {
        if (Duplicate(book.Title))
        {
            Console.WriteLine("Duplicate Book Are Not Allowed");
            return;
        }


        BookNode newNode = new BookNode(book);
        if(head == null)
        {
            head = newNode;
            return;
        }

        BookNode temp = head;
        while(temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = newNode;
        
    }

    //============= REMOVE BOOK =================
    public void RemoveBook(string title)
    {
        if(head == null)
        {
            Console.WriteLine("Empty Book Shelf");
            return;
        }

        if(head.Data.Title == title)
        {
            head = head.Next;
            return;
        }

        BookNode temp = head;
        while(temp.Next != null && temp.Next.Data.Title != title)
        {
            temp = temp.Next;
        }

        if(temp.Next != null)
        {
            temp.Next = temp.Next.Next;
        }
    }

    //================ Check Duplicate ===================
    public bool Duplicate(string title)
    {
        BookNode temp = head;
        while(temp != null)
        {
            if(temp.Data.Title == title)
            {
                return true;
            }
            temp = temp.Next;
        }
        return false;
    }

    public void Display()
    {
        BookNode temp = head;
        while(temp != null)
        {
            Console.WriteLine(" "+temp.Data.Title+" - "+temp.Data.Author);
            temp = temp.Next;
        }
    }
}

// --------------- GENRE NODE (HASH BUCKET) ------------------
class GenreNode
{
    public string Genre;
    public BookLinkedList Books;
    public GenreNode Next;

    public GenreNode(string genre)
    {
        Genre = genre;
        Books = new BookLinkedList();
        Next = null;
    }
}

//-------------------- CUSTOM HASH MAP --------------------
class GenreHashMap
{
    private GenreNode[] table;
    private int size = 10;

    //Constructor and implement table
    public GenreHashMap()
    {
        table = new GenreNode[size];
    }

    //Claculate index
    private int Hash(string genre)
    {
        return genre.Length % size;
    }

    public void AddBook(string genre, Book book)
    {
        int index = Hash(genre);
        GenreNode node = table[index];

        if(node == null)
        {
            table[index] = new GenreNode(genre);
            table[index].Books.AddBook(book);
            return;
        }

        GenreNode prev = null;
        while(node != null)
        {
            if(node.Genre == genre)
            {
                node.Books.AddBook(book);
                return;
            }
            prev = node;
            node = node.Next;
        }

        prev.Next = new GenreNode(genre);
        prev.Next.Books.AddBook(book);
    }

    public void RemoveBook(string genre, string title)
    {
        int index = Hash(genre);
        GenreNode node = table[index];

        while(node != null)
        {
            if(node.Genre == genre)
            {
                node.Books.RemoveBook(title);
                return;
            }
            node= node.Next;
        }
    }

    public void DisplayLibrary()
    {
        for(int i = 0; i < size; i++){
            GenreNode node = table[i];

            while(node != null)
            {
                Console.WriteLine("Genre: "+node.Genre);
                node.Books.Display();
                node = node.Next;
            }
        }
    }
}
class BookShelf
{
    static void Main(string[] args)
    {
        GenreHashMap library = new GenreHashMap();

        library.AddBook("Fiction", new Book("1984","Devansh Singh"));
        library.AddBook("Fiction", new Book("Animal Farm", "George Orwell"));
        library.AddBook("Science", new Book("Brief History of Time", "Stephen Hawking"));
        library.AddBook("Fiction", new Book("1984", "George Orwell")); // Duplicate

        Console.WriteLine("\nLibrary Catalog: ");
        library.DisplayLibrary();

        Console.WriteLine("\nBorrowing Animal Farms....\n");
        library.RemoveBook("Fiction","Animal Farm");

        library.DisplayLibrary();
    }
}