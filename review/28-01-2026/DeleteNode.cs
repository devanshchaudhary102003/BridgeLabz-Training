using System;

class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class LinkedList
{
    public Node Head;

    public void AddAtBeginning(int data)
    {
        Node newNode = new Node(data);
        newNode.Next = Head;
        Head = newNode;
    }

    public void Display()
    {
        Node temp = Head;
        while (temp != null)
        {
            Console.Write(temp.Data + " -> ");
            temp = temp.Next;
        }
        Console.WriteLine("null");
    }

    public void DeleteGivenNode(Node node)
    {
        if (node == null || node.Next == null)
        {
            Console.WriteLine("Cannot delete: node is null or it is the last node.");
            return;
        }

        node.Data = node.Next.Data;
        node.Next = node.Next.Next;
    }

    public Node FindFirst(int value)
    {
        Node temp = Head;
        while (temp != null)
        {
            if (temp.Data == value) return temp;
            temp = temp.Next;
        }
        return null;
    }
}

class DeleteNode
{
    static void Main()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddAtBeginning(1);
        linkedList.AddAtBeginning(2);
        linkedList.AddAtBeginning(3);
        linkedList.AddAtBeginning(4);
        linkedList.AddAtBeginning(5);

        Console.WriteLine("Original Linked List:");
        linkedList.Display(); 

        Node nodeToDelete = linkedList.FindFirst(4);
        Console.WriteLine("After Deleting Node");
        linkedList.DeleteGivenNode(nodeToDelete);

        linkedList.Display(); 
    }
}
