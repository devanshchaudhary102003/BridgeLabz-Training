using System;

class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val)
    {
        this.val = val;
        this.next = null;
    }
}

class ReverseTheList
{
    static ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode current = head;

        while (current != null)
        {
            ListNode nextNode = current.next;
            current.next = prev;
            prev = current;
            current = nextNode;
        }

        return prev;
    }

    static void PrintList(ListNode head)
    {
        while (head != null)
        {
            Console.Write(head.val + " -> ");
            head = head.next;
        }
        Console.WriteLine("null");
    }

    static void Main(string[] args)
    {
        Console.Write("Enter number of nodes: ");
        int n = int.Parse(Console.ReadLine());

        ListNode head = null, tail = null;

        Console.WriteLine("Enter node values:");
        for (int i = 0; i < n; i++)
        {
            int val = int.Parse(Console.ReadLine());
            ListNode node = new ListNode(val);

            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.next = node;
                tail = node;
            }
        }

        Console.WriteLine("\nOriginal List:");
        PrintList(head);

        head = ReverseList(head);

        Console.WriteLine("\nReversed List:");
        PrintList(head);
    }
}
