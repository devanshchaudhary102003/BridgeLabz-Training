
using System;

// Ticket Node
class TicketNode
{
    public int TicketId;
    public string CustomerName;
    public string MovieName;
    public string SeatNumber;
    public string BookingTime;

    public TicketNode next;

    public TicketNode(int id, string customer, string movie, string seat, string time)
    {
        TicketId = id;
        CustomerName = customer;
        MovieName = movie;
        SeatNumber = seat;
        BookingTime = time;
        next = null;
    }
}

// Circular Linked List
class TicketCircularLinkedList
{
    private TicketNode head;
    private int count = 0;

    // Add ticket at end
    public void AddTicket(int id, string customer, string movie, string seat, string time)
    {
        TicketNode newNode = new TicketNode(id, customer, movie, seat, time);

        if (head == null)
        {
            head = newNode;
            newNode.next = head;
        }
        else
        {
            TicketNode temp = head;
            while (temp.next != head)
            {
                temp = temp.next;
            }

            temp.next = newNode;
            newNode.next = head;
        }
        count++;
    }

    // Remove ticket by ID
    public void RemoveTicket(int id)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }

        TicketNode temp = head;
        TicketNode prev = null;

        do
        {
            if (temp.TicketId == id)
            {
                if (temp == head)
                {
                    TicketNode last = head;
                    while (last.next != head)
                    {
                        last = last.next;
                    }

                    if (head.next == head)
                    {
                        head = null;
                    }
                    else
                    {
                        last.next = head.next;
                        head = head.next;
                    }
                }
                else
                {
                    prev.next = temp.next;
                }

                count--;
                Console.WriteLine("Ticket cancelled successfully.");
                return;
            }

            prev = temp;
            temp = temp.next;

        } while (temp != head);

        Console.WriteLine("Ticket not found.");
    }

    // Display all tickets
    public void DisplayTickets()
    {
        if (head == null)
        {
            Console.WriteLine("No tickets to display.");
            return;
        }

        TicketNode temp = head;
        Console.WriteLine("\nCurrent Booked Tickets:");

        do
        {
            Console.WriteLine(
                "Ticket ID: " + temp.TicketId +
                ", Customer: " + temp.CustomerName +
                ", Movie: " + temp.MovieName +
                ", Seat: " + temp.SeatNumber +
                ", Time: " + temp.BookingTime
            );

            temp = temp.next;
        } while (temp != head);
    }

    // Search by customer name
    public void SearchByCustomer(string customer)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }

        TicketNode temp = head;
        bool found = false;

        do
        {
            if (temp.CustomerName.Equals(customer, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(
                    "Ticket ID: " + temp.TicketId +
                    ", Movie: " + temp.MovieName +
                    ", Seat: " + temp.SeatNumber +
                    ", Time: " + temp.BookingTime
                );
                found = true;
            }
            temp = temp.next;
        } while (temp != head);

        if (!found)
            Console.WriteLine("No ticket found for this customer.");
    }

    // Search by movie name
    public void SearchByMovie(string movie)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }

        TicketNode temp = head;
        bool found = false;

        do
        {
            if (temp.MovieName.Equals(movie, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(
                    "Ticket ID: " + temp.TicketId +
                    ", Customer: " + temp.CustomerName +
                    ", Seat: " + temp.SeatNumber +
                    ", Time: " + temp.BookingTime
                );
                found = true;
            }
            temp = temp.next;
        } while (temp != head);

        if (!found)
            Console.WriteLine("No tickets found for this movie.");
    }

    // Count tickets
    public void CountTickets()
    {
        Console.WriteLine("Total booked tickets: " + count);
    }
}

// Main class
class OnlineTicketReservationSystem
{
    static void Main(string[] args)
    {
        TicketCircularLinkedList system = new TicketCircularLinkedList();

        system.AddTicket(101, "Amit", "Inception", "A1", "10:00 AM");
        system.AddTicket(102, "Neha", "Avatar", "B3", "11:30 AM");
        system.AddTicket(103, "Amit", "Inception", "A2", "10:00 AM");

        system.DisplayTickets();

        Console.WriteLine("\nSearch by Customer:");
        system.SearchByCustomer("Amit");

        Console.WriteLine("\nSearch by Movie:");
        system.SearchByMovie("Avatar");

        Console.WriteLine("\nCancel Ticket:");
        system.RemoveTicket(102);

        system.DisplayTickets();
        system.CountTickets();
    }
}
