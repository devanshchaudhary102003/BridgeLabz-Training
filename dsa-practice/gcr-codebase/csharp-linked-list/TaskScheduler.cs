using System;

// Node class
class TaskNode
{
    public int TaskId;
    public string TaskName;
    public string Priority;
    public string DueDate;

    public TaskNode next;

    public TaskNode(int id, string name, string priority, string dueDate)
    {
        TaskId = id;
        TaskName = name;
        Priority = priority;
        DueDate = dueDate;
        next = null;
    }
}

// Circular Linked List
class TaskCircularLinkedList
{
    private TaskNode head;
    private TaskNode current;

    // Add at beginning
    public void AddAtBeginning(int id, string name, string priority, string dueDate)
    {
        TaskNode newNode = new TaskNode(id, name, priority, dueDate);

        if (head == null)
        {
            head = newNode;
            newNode.next = head;
            current = head;
        }
        else
        {
            TaskNode temp = head;
            while (temp.next != head)
            {
                temp = temp.next;
            }

            newNode.next = head;
            temp.next = newNode;
            head = newNode;
        }
    }

    // Add at end
    public void AddAtEnd(int id, string name, string priority, string dueDate)
    {
        TaskNode newNode = new TaskNode(id, name, priority, dueDate);

        if (head == null)
        {
            head = newNode;
            newNode.next = head;
            current = head;
        }
        else
        {
            TaskNode temp = head;
            while (temp.next != head)
            {
                temp = temp.next;
            }

            temp.next = newNode;
            newNode.next = head;
        }
    }

    // Add at specific position
    public void AddAtPosition(int position, int id, string name, string priority, string dueDate)
    {
        if (position <= 1 || head == null)
        {
            AddAtBeginning(id, name, priority, dueDate);
            return;
        }

        TaskNode temp = head;

        for (int i = 1; i < position - 1 && temp.next != head; i++)
        {
            temp = temp.next;
        }

        TaskNode newNode = new TaskNode(id, name, priority, dueDate);
        newNode.next = temp.next;
        temp.next = newNode;
    }

    // Remove by Task ID
    public void RemoveByTaskId(int id)
    {
        if (head == null)
        {
            Console.WriteLine("Task list is empty.");
            return;
        }

        TaskNode temp = head;
        TaskNode prev = null;

        do
        {
            if (temp.TaskId == id)
            {
                if (temp == head)
                {
                    TaskNode last = head;
                    while (last.next != head)
                    {
                        last = last.next;
                    }

                    if (head.next == head)
                    {
                        head = null;
                        current = null;
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

                Console.WriteLine("Task removed successfully.");
                return;
            }

            prev = temp;
            temp = temp.next;

        } while (temp != head);

        Console.WriteLine("Task not found.");
    }

    // View current task and move to next
    public void ViewCurrentAndMoveNext()
    {
        if (current == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.WriteLine(
            "Current Task -> ID: " + current.TaskId +
            ", Name: " + current.TaskName +
            ", Priority: " + current.Priority +
            ", Due Date: " + current.DueDate
        );

        current = current.next;
    }

    // Display all tasks
    public void DisplayAllTasks()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks to display.");
            return;
        }

        TaskNode temp = head;
        Console.WriteLine("\nAll Tasks:");

        do
        {
            Console.WriteLine(
                "ID: " + temp.TaskId +
                ", Name: " + temp.TaskName +
                ", Priority: " + temp.Priority +
                ", Due Date: " + temp.DueDate
            );

            temp = temp.next;
        } while (temp != head);
    }

    // Search by priority
    public void SearchByPriority(string priority)
    {
        if (head == null)
        {
            Console.WriteLine("Task list is empty.");
            return;
        }

        TaskNode temp = head;
        bool found = false;

        do
        {
            if (temp.Priority.Equals(priority, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(
                    "ID: " + temp.TaskId +
                    ", Name: " + temp.TaskName +
                    ", Priority: " + temp.Priority +
                    ", Due Date: " + temp.DueDate
                );
                found = true;
            }

            temp = temp.next;

        } while (temp != head);

        if (!found)
            Console.WriteLine("No tasks found with this priority.");
    }
}

// Main class
class TaskScheduler
{
    static void Main(string[] args)
    {
        TaskCircularLinkedList scheduler = new TaskCircularLinkedList();

        scheduler.AddAtBeginning(1, "Design Module", "High", "10-02-2026");
        scheduler.AddAtEnd(2, "Write Code", "Medium", "12-02-2026");
        scheduler.AddAtPosition(2, 3, "Testing", "High", "15-02-2026");

        scheduler.DisplayAllTasks();

        Console.WriteLine("\nView Current Task:");
        scheduler.ViewCurrentAndMoveNext();
        scheduler.ViewCurrentAndMoveNext();

        Console.WriteLine("\nSearch by Priority:");
        scheduler.SearchByPriority("High");

        Console.WriteLine("\nRemove Task:");
        scheduler.RemoveByTaskId(2);

        scheduler.DisplayAllTasks();
    }
}
