using System;

// Book Node
class BookNode
{
    public int BookId;
    public string Title;
    public string Author;
    public string Genre;
    public string Availability;

    public BookNode next;
    public BookNode prev;

    public BookNode(int id, string title, string author, string genre, string availability)
    {
        BookId = id;
        Title = title;
        Author = author;
        Genre = genre;
        Availability = availability;
        next = null;
        prev = null;
    }
}

// Doubly Linked List
class LibraryDoublyLinkedList
{
    private BookNode head;
    private BookNode tail;
    private int count = 0;

    // Add at beginning
    public void AddAtBeginning(int id, string title, string author, string genre, string availability)
    {
        BookNode newNode = new BookNode(id, title, author, genre, availability);

        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            newNode.next = head;
            head.prev = newNode;
            head = newNode;
        }
        count++;
    }

    // Add at end
    public void AddAtEnd(int id, string title, string author, string genre, string availability)
    {
        BookNode newNode = new BookNode(id, title, author, genre, availability);

        if (tail == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
        }
        count++;
    }

    // Add at specific position
    public void AddAtPosition(int position, int id, string title, string author, string genre, string availability)
    {
        if (position <= 1)
        {
            AddAtBeginning(id, title, author, genre, availability);
            return;
        }

        BookNode temp = head;

        for (int i = 1; i < position - 1 && temp != null; i++)
        {
            temp = temp.next;
        }

        if (temp == null || temp.next == null)
        {
            AddAtEnd(id, title, author, genre, availability);
        }
        else
        {
            BookNode newNode = new BookNode(id, title, author, genre, availability);
            newNode.next = temp.next;
            newNode.prev = temp;
            temp.next.prev = newNode;
            temp.next = newNode;
            count++;
        }
    }

    // Remove by Book ID
    public void RemoveByBookId(int id)
    {
        BookNode temp = head;

        while (temp != null)
        {
            if (temp.BookId == id)
            {
                if (temp == head)
                {
                    head = head.next;
                    if (head != null)
                        head.prev = null;
                }
                else if (temp == tail)
                {
                    tail = tail.prev;
                    tail.next = null;
                }
                else
                {
                    temp.prev.next = temp.next;
                    temp.next.prev = temp.prev;
                }

                count--;
                Console.WriteLine("Book removed successfully.");
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Book not found.");
    }

    // Search by Title
    public void SearchByTitle(string title)
    {
        BookNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                DisplayBook(temp);
                found = true;
            }
            temp = temp.next;
        }

        if (!found)
            Console.WriteLine("No book found with this title.");
    }

    // Search by Author
    public void SearchByAuthor(string author)
    {
        BookNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                DisplayBook(temp);
                found = true;
            }
            temp = temp.next;
        }

        if (!found)
            Console.WriteLine("No books found by this author.");
    }

    // Update availability
    public void UpdateAvailability(int id, string newStatus)
    {
        BookNode temp = head;

        while (temp != null)
        {
            if (temp.BookId == id)
            {
                temp.Availability = newStatus;
                Console.WriteLine("Availability status updated.");
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Book not found.");
    }

    // Display forward
    public void DisplayForward()
    {
        BookNode temp = head;
        Console.WriteLine("\nBooks (Forward Order):");

        while (temp != null)
        {
            DisplayBook(temp);
            temp = temp.next;
        }
    }

    // Display reverse
    public void DisplayReverse()
    {
        BookNode temp = tail;
        Console.WriteLine("\nBooks (Reverse Order):");

        while (temp != null)
        {
            DisplayBook(temp);
            temp = temp.prev;
        }
    }

    // Count books
    public void CountBooks()
    {
        Console.WriteLine("Total number of books: " + count);
    }

    private void DisplayBook(BookNode book)
    {
        Console.WriteLine(
            "Book ID: " + book.BookId +
            ", Title: " + book.Title +
            ", Author: " + book.Author +
            ", Genre: " + book.Genre +
            ", Availability: " + book.Availability
        );
    }
}

// Main class
class LibraryManagementSystem
{
    static void Main(string[] args)
    {
        LibraryDoublyLinkedList library = new LibraryDoublyLinkedList();

        library.AddAtBeginning(1, "Clean Code", "Robert Martin", "Programming", "Available");
        library.AddAtEnd(2, "The Alchemist", "Paulo Coelho", "Fiction", "Issued");
        library.AddAtPosition(2, 3, "Atomic Habits", "James Clear", "Self Help", "Available");

        library.DisplayForward();
        library.DisplayReverse();

        Console.WriteLine("\nSearch by Author:");
        library.SearchByAuthor("Robert Martin");

        Console.WriteLine("\nUpdate Availability:");
        library.UpdateAvailability(2, "Available");

        Console.WriteLine("\nRemove Book:");
        library.RemoveByBookId(1);

        library.DisplayForward();
        library.CountBooks();
    }
}
