using System;
using System.Collections.Generic;
class Reverse
{
    public static void ReverseList(List<int> list)
    {
        int left = 0;
        int right = list.Count - 1;

        while(left < right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;

            left++;
            right--;
        }
    }
    public static LinkedList<int> ReverseLinkedList(LinkedList<int> list)
    {
        LinkedList<int> ReverseLinkedList = new LinkedList<int>();

        // Traverse from last to first
        var current = list.Last;

        while(current != null)
        {
            ReverseLinkedList.AddLast(current.Value);
            current = current.Previous;
        }
        return ReverseLinkedList;
    }
}
class ReverseLL
{
    static void Main(string[] args)
    {
        // Reverse reverse = new Reverse();

        List<int> list = new List<int>{1,2,3,4,5};
        Reverse.ReverseList(list);
        Console.WriteLine("Reversed List: "+string.Join(", ",list));

        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.AddLast(1);
        linkedList.AddLast(2);
        linkedList.AddLast(3);
        linkedList.AddLast(4);
        linkedList.AddLast(5);

        LinkedList<int> reversedLinkedList = Reverse.ReverseLinkedList(linkedList);

        Console.WriteLine("Reversed Linked List: ");
        foreach(int value in reversedLinkedList)
        {
            Console.Write(value+" ");
        }
    }
}