using System;

// Process Node
class ProcessNode
{
    public int ProcessId;
    public int BurstTime;
    public int RemainingTime;
    public int Priority;

    public int WaitingTime;
    public int TurnAroundTime;

    public ProcessNode next;

    public ProcessNode(int id, int burst, int priority)
    {
        ProcessId = id;
        BurstTime = burst;
        RemainingTime = burst;
        Priority = priority;
        WaitingTime = 0;
        TurnAroundTime = 0;
        next = null;
    }
}

// Circular Linked List for Round Robin
class RoundRobinScheduler
{
    private ProcessNode head;
    private int processCount = 0;

    // Add process at end
    public void AddProcess(int id, int burst, int priority)
    {
        ProcessNode newNode = new ProcessNode(id, burst, priority);

        if (head == null)
        {
            head = newNode;
            newNode.next = head;
        }
        else
        {
            ProcessNode temp = head;
            while (temp.next != head)
            {
                temp = temp.next;
            }
            temp.next = newNode;
            newNode.next = head;
        }
        processCount++;
    }

    // Remove process by ID
    private void RemoveProcess(int id)
    {
        if (head == null)
            return;

        ProcessNode temp = head;
        ProcessNode prev = null;

        do
        {
            if (temp.ProcessId == id)
            {
                if (temp == head)
                {
                    ProcessNode last = head;
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
                processCount--;
                return;
            }

            prev = temp;
            temp = temp.next;

        } while (temp != head);
    }

    // Display processes
    public void DisplayProcesses()
    {
        if (head == null)
        {
            Console.WriteLine("No processes in queue.");
            return;
        }

        ProcessNode temp = head;
        Console.WriteLine("Processes in Queue:");

        do
        {
            Console.WriteLine(
                "PID: " + temp.ProcessId +
                ", Remaining Time: " + temp.RemainingTime +
                ", Priority: " + temp.Priority
            );
            temp = temp.next;
        } while (temp != head);
    }

    // Round Robin Simulation
    public void Simulate(int timeQuantum)
    {
        if (head == null)
        {
            Console.WriteLine("No processes to schedule.");
            return;
        }

        int currentTime = 0;
        ProcessNode temp = head;

        while (processCount > 0)
        {
            if (temp.RemainingTime > 0)
            {
                if (temp.RemainingTime > timeQuantum)
                {
                    currentTime += timeQuantum;
                    temp.RemainingTime -= timeQuantum;
                }
                else
                {
                    currentTime += temp.RemainingTime;
                    temp.RemainingTime = 0;

                    temp.TurnAroundTime = currentTime;
                    temp.WaitingTime = temp.TurnAroundTime - temp.BurstTime;

                    RemoveProcess(temp.ProcessId);
                }

                Console.WriteLine("\nAfter Round:");
                DisplayProcesses();
            }

            if (head == null)
                break;

            temp = temp.next;
        }
    }
}

// Main class
class RoundRobinSchedulingAlgorithm
{
    static void Main(string[] args)
    {
        RoundRobinScheduler scheduler = new RoundRobinScheduler();

        scheduler.AddProcess(1, 10, 1);
        scheduler.AddProcess(2, 5, 2);
        scheduler.AddProcess(3, 8, 1);

        int timeQuantum = 3;

        Console.WriteLine("Starting Round Robin Scheduling");
        scheduler.Simulate(timeQuantum);

        Console.WriteLine("\nScheduling Completed");
    }
}
