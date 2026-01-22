using System;
using System.Collections.Generic;
class Node
{
    public char Data;
    public Node Next;

    public Node(char data)
    {
        Data = data;
        Next = null;
    }
}

class LinkedList
{
    public Node Head;

    public void AddLast(char data)
    {
        Node newNode = new Node(data);
        if(Head == null)
        {
            Head = newNode;
            return;
        }

        Node temp = Head;
        while(temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = newNode;
    }

    public void NthNodeFromEnd(int n)
    {
        Node fast = Head;
        Node slow = fast;

        for(int i = 0; i < n; i++)
        {
            if(fast == null)
            {
                Console.WriteLine("N is Greater than the list length");
                return;
            }
            fast = fast.Next;
        }

        while(fast != null)
        {
            fast = fast.Next;
            slow = slow.Next;
        }

        Console.WriteLine("Nth Element From end: "+slow.Data);
    }
}
class NthElementFromTheEnd
{
    static void Main(string[] args)
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddLast('A');
        linkedList.AddLast('B');
        linkedList.AddLast('C');
        linkedList.AddLast('D');
        linkedList.AddLast('E');

        linkedList.NthNodeFromEnd(2);
    }
}