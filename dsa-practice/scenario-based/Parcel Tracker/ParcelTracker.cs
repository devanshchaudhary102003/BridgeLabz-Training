using System;
class StageNode
{
    public string StageName;
    public StageNode Next;

    public StageNode(string stageName)
    {
        StageName = stageName;
    }
}

class ParcelTrackerList
{
    public StageNode head;

    public ParcelTrackerList()
    {
        head = new StageNode("Packed");
        head.Next = new StageNode("Shipped");
        head.Next.Next = new StageNode("In Transit");
        head.Next.Next.Next = new StageNode("Delivered");
    }

    // Forward tracking
    public void ParcelTracking()
    {
        if(head == null)
        {
            Console.WriteLine("Parcel Lost! No Tracking Data Available...");
            return;
        }

        StageNode temp = head;
        Console.WriteLine("Parcel Tracking");

        while(temp != null)
        {
            Console.WriteLine(temp.StageName);
            
            if(temp.Next != null)
            {
                Console.WriteLine("->");
            }

            temp = temp.Next;
            Console.WriteLine();
        }
    }

    // Add intermediate checkpoint
    public void AddCheckPoint(string afterStage, string newStage)
    {
        if(head == null)
        {
            Console.WriteLine("Cannot Add CheckPoint. Parcel Is Lost");
            return;
        }

        StageNode temp = head;
        
        while(temp != null)
        {
            if (temp.StageName.Equals(afterStage, StringComparison.OrdinalIgnoreCase))
            {
                StageNode newNode = new StageNode(newStage);
                newNode.Next = temp.Next;
                temp.Next = newNode;
                
                Console.WriteLine("Checkout Point: "+newStage+" added After: "+afterStage);
                return;
            }

            temp = temp.Next;
        }

        Console.WriteLine("Stage Not Found. Checkout Not Added");
    }

    public void MarkParcelLost()
    {
        head = null;
        Console.WriteLine("Parcel Marked As Lost.");
    }
}


class ParcelTracker
{
    static void Main(string[] args)
    {
        ParcelTrackerList tracker = new ParcelTrackerList();

        int choice;

        do
        {
            Console.WriteLine("\n======== Parcel Tracker Menu ===========");
            Console.WriteLine("1. Track Parcel");
            Console.WriteLine("2. Add Intermediate Checkpoint");
            Console.WriteLine("3. Mark Parcel As Lost");
            Console.WriteLine("0. Exit");

            Console.WriteLine("Enter Choices: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    tracker.ParcelTracking();
                    break;

                case 2:
                    Console.WriteLine("Enter Existing Point: ");
                    string afterStage = Console.ReadLine();

                    Console.WriteLine("Enter New CheckPoint: ");
                    string newStage = Console.ReadLine();

                    tracker.AddCheckPoint(afterStage,newStage);
                    break;

                case 3:
                    tracker.MarkParcelLost();
                    break;

                case 0:
                    Console.WriteLine("Existing Parcel Tracker.");
                    break;

                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }
        }while(choice != 0);
    }
}