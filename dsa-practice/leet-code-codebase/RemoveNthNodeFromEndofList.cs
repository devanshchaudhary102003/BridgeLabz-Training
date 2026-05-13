/*Given the head of a linked list, remove the nth 
node from the end of the list and return its head.*/
using System;
public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode temp = head;
        int count = 0;

        // Count nodes
        while (temp != null)
        {
            count++;
            temp = temp.next;
        }

        // If head needs to be removed
        if (n == count)
        {
            return head.next;
        }

        int pos = count - n;
        temp = head;

        // Move to node before the one to delete
        for (int i = 1; i < pos; i++)
        {
            temp = temp.next;
        }

        temp.next = temp.next.next;

        return head;
    }
}

class RemoveNthNodeFromEndofList

{
    static void Main(string[] args)
    {
        // Creating linked list: 1 -> 2 -> 3 -> 4 -> 5
        ListNode head = new ListNode(1,
            new ListNode(2,
            new ListNode(3,
            new ListNode(4,
            new ListNode(5)))));

        Solution sol = new Solution();
        head = sol.RemoveNthFromEnd(head, 2);

        // Print updated list
        Console.WriteLine("Updated Linked List:");
        while (head != null)
        {
            Console.Write(head.val + " ");
            head = head.next;
        }
    }
}
