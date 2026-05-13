using System;
using System.Collections.Generic;
class VehicleNode
{
    public string VehicleNumber;
    public VehicleNode Next;

    public VehicleNode(string number)
    {
        VehicleNumber = number;
        Next = null;
    }
}

class CircularLinkedList
{
    private VehicleNode tail;
    public void AddVehicle(string number)
    {
        VehicleNode newNode = new VehicleNode(number);

        if(tail == null)
        {
            tail = newNode;
            tail.Next = tail;
        }

        else
        {
            newNode.Next = tail.Next;
            tail.Next = newNode;
            tail = newNode;
        }

        Console.WriteLine("vehicle Entered RoundAbout: "+number);
    }

    public void RemoveVehicle()
    {
        if(tail == null)
        {
            Console.WriteLine("RoundAbout is empty");
            return;
        }
        VehicleNode head = tail.Next;

        if(head == tail)
        {
            Console.WriteLine("Vehicle Exited: "+head.VehicleNumber);
            // tail = null;
        }

        else
        {
            Console.WriteLine("Vehicle Exited: "+head.VehicleNumber);
            tail.Next = head.Next;
        }
    }

    public void Display()
    {
        if(tail == null)
        {
            Console.WriteLine("RoundAbout is empty");
            return;
        }

        VehicleNode head = tail.Next;
        Console.WriteLine("Round About: ");

        do
        {
            Console.WriteLine(head.VehicleNumber+"->");
            head = head.Next;

        }while(head != tail.Next);

        Console.WriteLine("(Back to Start)");
    }

    public bool isEmpty()
    {
        return tail == null;
    }
}

class VehicleQueue
{
    private Queue<string> queue = new Queue<string>();
    private int Capacity;

    public VehicleQueue(int size)
    {
        Capacity = size;
    }

    public void Enqueue(string vehicle)
    {
        if(queue.Count == Capacity)
        {
            Console.WriteLine("Queue Overflow! Cannot Add Vehicle");
            return;
        }

        queue.Enqueue(vehicle);
        Console.WriteLine("Vehicle Added to Waiting Queue: "+vehicle);
    }

    public string Dequeue()
    {
        if(queue.Count == 0)
        {
            Console.WriteLine("Queue Underflow! No Vehicle Waiting");
            return null;
        }
        return queue.Dequeue();
    }

    public bool isEmpty()
    {
        return queue.Count == 0;
    }
}
class TrafficManager
{
    static void Main()
    {
        CircularLinkedList roundabout = new CircularLinkedList();
        VehicleQueue waitingQueue = new VehicleQueue(3);

        while (true)
        {
            Console.WriteLine("1. Add Vehicle TO Queue");
            Console.WriteLine("2. Move Vehicle To Roundabout");
            Console.WriteLine("3. Exit Vehicle From Roundabout");
            Console.WriteLine("4. Display Roundabout");
            Console.WriteLine("5. Exit");

            Console.WriteLine("Enter Choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Vehicle Number: ");
                    waitingQueue.Enqueue(Console.ReadLine());
                    break;

                case 2:
                    if(waitingQueue.isEmpty())
                        roundabout.AddVehicle(waitingQueue.Dequeue());
                    
                    else
                        Console.WriteLine("No Vehicle Waiting");
                    break;

                case 3:
                    roundabout.RemoveVehicle();
                    break;

                case 4:
                    roundabout.Display();
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }
}