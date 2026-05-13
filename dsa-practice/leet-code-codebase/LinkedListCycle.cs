/*Given head, the head of a linked list, determine if the linked list has a cycle in it.
There is a cycle in a linked list if there is some node in the list that 
can be reached again by continuously following the next pointer. Internally, 
pos is used to denote the index of the node that tail's next pointer is connected to. 
Note that pos is not passed as a parameter.
Return true if there is a cycle in the linked list. Otherwise, return false.*/
using System;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}

public class Solution
{
    public bool HasCycle(ListNode head)
    {
        if (head == null)
            return false;

        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast)
            {
                return true;
            }
        }
        return false;
    }
}

class LinkedListCycle
{
    static void Main(string[] args)
    {
        // Creating linked list: 1 -> 2 -> 3 -> 4 -> back to 2 (cycle)
        ListNode head = new ListNode(1);
        ListNode second = new ListNode(2);
        ListNode third = new ListNode(3);
        ListNode fourth = new ListNode(4);

        head.next = second;
        second.next = third;
        third.next = fourth;
        fourth.next = second; // creates cycle

        Solution solution = new Solution();
        bool hasCycle = solution.HasCycle(head);

        Console.WriteLine("Linked List has cycle: " + hasCycle);

        Console.ReadLine();
    }
}
