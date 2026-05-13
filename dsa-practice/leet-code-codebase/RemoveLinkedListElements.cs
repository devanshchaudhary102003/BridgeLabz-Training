using System;

/**
 * Definition for singly-linked list.
 */
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
    public ListNode RemoveElements(ListNode head, int val)
    {
        ListNode dummy = new ListNode(0, head);
        ListNode prev = dummy;
        ListNode curr = head;

        while (curr != null)
        {
            if (curr.val == val)
            {
                prev.next = curr.next; // skip node
            }
            else
            {
                prev = curr;
            }

            curr = curr.next;
        }

        return dummy.next;
    }
}

class RemoveLinkedListElements
{
    static void Main(string[] args)
    {
        // Create linked list: 1 -> 2 -> 6 -> 3 -> 4 -> 5 -> 6
        ListNode head = new ListNode(1,
                            new ListNode(2,
                            new ListNode(6,
                            new ListNode(3,
                            new ListNode(4,
                            new ListNode(5,
                            new ListNode(6)))))));

        Solution solution = new Solution();
        int valToRemove = 6;

        head = solution.RemoveElements(head, valToRemove);

        // Print result
        Console.WriteLine("Linked List after removing " + valToRemove + ":");
        PrintList(head);
    }

    static void PrintList(ListNode head)
    {
        while (head != null)
        {
            Console.Write(head.val + " ");
            head = head.next;
        }
        Console.WriteLine();
    }
}
