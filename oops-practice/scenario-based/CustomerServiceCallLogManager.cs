using System;
class CallLog
{
    public string PhoneNumber;
    public string Message;
    public DateTime Timestamp;

    public CallLog(string phoneNumber, string message, DateTime timestamp)
    {
        PhoneNumber = phoneNumber;
        Message = message;
        Timestamp = timestamp;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Phone Number: "+PhoneNumber);
        Console.WriteLine("Message: "+Message);
        Console.WriteLine("Timestamp: "+Timestamp);
        Console.WriteLine("-------------------------------------");
    }
}

class CallLogManager
{
    private CallLog[] callLogs;
    private int count;

    public CallLogManager(int size)
    {
        callLogs = new CallLog[size];
        count = 0;
    }

    public void AddCallLog()
    {
        if(count >= callLogs.Length)
        {
            Console.WriteLine("Call log storage is full");
            return;
        }

        Console.WriteLine("Enter Phone Number: ");
        string Phone = Console.ReadLine();

        Console.WriteLine("Enter Message: ");
        string message = Console.ReadLine();

        callLogs[count] = new CallLog(Phone,message,DateTime.Now);
        count++;

        Console.WriteLine("Call log added successfully");
    }

    public void SearchByKeyword()
    {
        Console.WriteLine("Enter Keyword: ");
        string Keyword = Console.ReadLine();
        bool found = false;

        for(int i = 0; i < count; i++)
        {
            if (callLogs[i].Message.Contains(Keyword))
            {
                callLogs[i].DisplayDetails();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No call logs found");
        }
    }

    public void FilterByTime()
    {
        Console.WriteLine("Enter Start DateTime (yyyy-MM-dd HH:mm): ");
        DateTime start = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter End DateTime (yyyy-MM-dd HH:mm): ");
        DateTime end = DateTime.Parse(Console.ReadLine());

        bool found = false;

        for(int i = 0; i < count; i++)
        {
            if(callLogs[i].Timestamp >= start && callLogs[i].Timestamp <= end)
            {
                callLogs[i].DisplayDetails();
                found=true;
            }
        }
        if (!found)
        {
            Console.WriteLine("No call logs found in this time range");
        }
    }
}
class CustomerServiceCallLogManager
{
    static void Main(string[] args)
    {
        CallLogManager manager = new CallLogManager(10);
        int choice;

        do
        {
            Console.WriteLine("\n ===========Call Log Manager ================");
            Console.WriteLine("1. Add Call Log");
            Console.WriteLine("2. Search by Keyword");
            Console.WriteLine("3. Filter By Time");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter Choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    manager.AddCallLog();
                    break;

                case 2:
                    manager.SearchByKeyword();
                    break;

                case 3:
                    manager.FilterByTime();
                    break;

                case 4:
                    Console.WriteLine("Thank You!");
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }while(choice != 4);
    }
}