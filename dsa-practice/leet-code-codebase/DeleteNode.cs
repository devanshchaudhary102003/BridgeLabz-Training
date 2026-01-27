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
    public void DeleteNode(ListNode node)
    {
        // Copy next node's value and bypass it
        node.val = node.next.val;
        node.next = node.next.next;
    }
}

class DeleteNode
{
    static void Main(string[] args)
    {
        // Create linked list: 4 -> 5 -> 1 -> 9
        ListNode head = new ListNode(4);
        head.next = new ListNode(5);
        head.next.next = new ListNode(1);
        head.next.next.next = new ListNode(9);

        // Suppose we want to delete node with value 5
        ListNode nodeToDelete = head.next;

        Solution sol = new Solution();
        sol.DeleteNode(nodeToDelete);

        // Print updated linked list
        Console.WriteLine("Linked List after deleting node:");
        ListNode temp = head;
        while (temp != null)
        {
            Console.Write(temp.val + " ");
            temp = temp.next;
        }
    }
}
