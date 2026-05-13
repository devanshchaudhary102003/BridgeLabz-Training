using System;

class BusStop
{
    public string StopName;
    public int StopNumber;
    public int PreviousDistance;

    public BusStop(string StopName,int StopNumber,int PreviousDistance)
    {
        this.StopName = StopName;
        this.StopNumber = StopNumber;
        this.PreviousDistance = PreviousDistance;
    }

    public int GetDistance()
    {
        return PreviousDistance;
    }

    public void DisplayStopDetails()
    {
        Console.WriteLine("Stop Name: "+StopName);

        Console.WriteLine("Stop Number: "+StopNumber);

        Console.WriteLine("Distance from Privios Stop: "+PreviousDistance+" KM ");
    }

    public bool AskPassenger()
    {
        Console.WriteLine("Choose 1 to get off at this stop");
        Console.WriteLine("Choose 2 to continue their Journey");

        int choice = Convert.ToInt16(Console.ReadLine());

        if(choice == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
class BusRouteDistanceTracker
{
    static void Main(string[] args)
    {   Console.WriteLine("Enter Total Number of Bus Stop");
        int Stop = Convert.ToInt32(Console.ReadLine());

        BusStop[] busStops = new BusStop[Stop];

        for(int i = 0; i < Stop; i++)
        {
            Console.WriteLine("Enter Details of stop :"+(i+1));

            Console.WriteLine("Stop Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Stop Number: ");
            int StopNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Distance from Privios Stop: ");
            int PreviousDistance = Convert.ToInt32(Console.ReadLine());

            busStops[i] = new BusStop(name,StopNumber,PreviousDistance);
        }

        int totalDistance = 0;

        Console.WriteLine("Journey Started");
        for(int i = 0; i < Stop; i++)
        {
            Console.WriteLine("You Have Reached");
            busStops[i].DisplayStopDetails();

            totalDistance = totalDistance + busStops[i].GetDistance();

            bool getOff = busStops[i].AskPassenger();

            if (getOff)
            {
                Console.WriteLine("PASSENGER GOT OFF");
                Console.WriteLine("TOTAL DISTANCE TRAVELLED: " + totalDistance + " KM");
                break;
            }
        }
        Console.WriteLine("JOURNEY ENDED");
    }
}