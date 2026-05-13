using System;

// Node class
class MovieNode
{
    public string Title;
    public string Director;
    public int Year;
    public double Rating;

    public MovieNode next;
    public MovieNode prev;

    public MovieNode(string title, string director, int year, double rating)
    {
        Title = title;
        Director = director;
        Year = year;
        Rating = rating;
        next = null;
        prev = null;
    }
}

// Doubly Linked List
class MovieDoublyLinkedList
{
    private MovieNode head;
    private MovieNode tail;

    // Add at beginning
    public void AddAtBeginning(string title, string director, int year, double rating)
    {
        MovieNode newNode = new MovieNode(title, director, year, rating);

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
    }

    // Add at end
    public void AddAtEnd(string title, string director, int year, double rating)
    {
        MovieNode newNode = new MovieNode(title, director, year, rating);

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
    }

    // Add at specific position
    public void AddAtPosition(int position, string title, string director, int year, double rating)
    {
        if (position <= 1)
        {
            AddAtBeginning(title, director, year, rating);
            return;
        }

        MovieNode temp = head;

        for (int i = 1; i < position - 1 && temp != null; i++)
        {
            temp = temp.next;
        }

        if (temp == null || temp.next == null)
        {
            AddAtEnd(title, director, year, rating);
        }
        else
        {
            MovieNode newNode = new MovieNode(title, director, year, rating);
            newNode.next = temp.next;
            newNode.prev = temp;
            temp.next.prev = newNode;
            temp.next = newNode;
        }
    }

    // Remove by title
    public void RemoveByTitle(string title)
    {
        MovieNode temp = head;

        while (temp != null)
        {
            if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
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

                Console.WriteLine("Movie removed successfully.");
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Movie not found.");
    }

    // Search by director
    public void SearchByDirector(string director)
    {
        MovieNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Director.Equals(director, StringComparison.OrdinalIgnoreCase))
            {
                DisplayMovie(temp);
                found = true;
            }
            temp = temp.next;
        }

        if (!found)
            Console.WriteLine("No movies found for this director.");
    }

    // Search by rating
    public void SearchByRating(double rating)
    {
        MovieNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Rating == rating)
            {
                DisplayMovie(temp);
                found = true;
            }
            temp = temp.next;
        }

        if (!found)
            Console.WriteLine("No movies found with this rating.");
    }

    // Update rating by title
    public void UpdateRating(string title, double newRating)
    {
        MovieNode temp = head;

        while (temp != null)
        {
            if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                temp.Rating = newRating;
                Console.WriteLine("Rating updated successfully.");
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Movie not found.");
    }

    // Display forward
    public void DisplayForward()
    {
        MovieNode temp = head;
        Console.WriteLine("\nMovies (Forward Order):");

        while (temp != null)
        {
            DisplayMovie(temp);
            temp = temp.next;
        }
    }

    // Display reverse
    public void DisplayReverse()
    {
        MovieNode temp = tail;
        Console.WriteLine("\nMovies (Reverse Order):");

        while (temp != null)
        {
            DisplayMovie(temp);
            temp = temp.prev;
        }
    }

    private void DisplayMovie(MovieNode movie)
    {
        Console.WriteLine(
            "Title: " + movie.Title +
            ", Director: " + movie.Director +
            ", Year: " + movie.Year +
            ", Rating: " + movie.Rating
        );
    }
}

// Main class
class MovieManagementSystem
{
    static void Main(string[] args)
    {
        MovieDoublyLinkedList movies = new MovieDoublyLinkedList();

        movies.AddAtBeginning("Inception", "Christopher Nolan", 2010, 8.8);
        movies.AddAtEnd("Interstellar", "Christopher Nolan", 2014, 8.6);
        movies.AddAtPosition(2, "Avatar", "James Cameron", 2009, 7.8);

        movies.DisplayForward();
        movies.DisplayReverse();

        Console.WriteLine("\nSearch by Director:");
        movies.SearchByDirector("Christopher Nolan");

        Console.WriteLine("\nUpdate Rating:");
        movies.UpdateRating("Avatar", 8.1);

        Console.WriteLine("\nRemove Movie:");
        movies.RemoveByTitle("Inception");

        movies.DisplayForward();
    }
}
