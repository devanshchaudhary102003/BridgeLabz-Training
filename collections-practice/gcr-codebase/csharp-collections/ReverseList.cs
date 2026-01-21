using System;
using System.Collections;
using System.Collections.Generic;

class ReverseList
{
    static void Main()
    {
        ReverseList obj = new ReverseList();
        obj.ReverseArrayList();
        obj.ReverseLL();
    }

    void ReverseArrayList()
    {
        ArrayList list = new ArrayList() { 1, 2, 3, 4, 5 };

        int left = 0;
        int right = list.Count - 1;

        while (left < right)
        {
            object temp = list[left];
            list[left] = list[right];
            list[right] = temp;

            left++;
            right--;
        }

        Console.WriteLine("Reversed ArrayList: " + string.Join(", ", list.ToArray()));
    }

    void ReverseLL()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(4);
        list.AddLast(5);

        // In-place reverse
        LinkedListNode<int> current = list.First;
        LinkedListNode<int> next;

        while (current != null)
        {
            next = current.Next;
            list.Remove(current);
            list.AddFirst(current);
            current = next;
        }

        Console.WriteLine("Reversed LinkedList: " + string.Join(", ", list));
    }
}