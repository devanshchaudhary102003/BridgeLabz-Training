using System;
using System.Collections.Generic;

class QueueUsingStacks
{
    // Two stacks
    private Stack<int> inStack = new Stack<int>();
    private Stack<int> outStack = new Stack<int>();

    // Enqueue operation
    public void Enqueue(int data)
    {
        inStack.Push(data);
        Console.WriteLine(data + " enqueued");
    }

    // Dequeue operation
    public int Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }

        // Transfer elements if needed
        if (outStack.Count == 0)
        {
            while (inStack.Count > 0)
            {
                outStack.Push(inStack.Pop());
            }
        }

        return outStack.Pop();
    }

    // Peek front element
    public int Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }

        if (outStack.Count == 0)
        {
            while (inStack.Count > 0)
            {
                outStack.Push(inStack.Pop());
            }
        }

        return outStack.Peek();
    }

    // Check if queue is empty
    public bool IsEmpty()
    {
        return inStack.Count == 0 && outStack.Count == 0;
    }
}

class ImplementQueueUsingStack
{
    static void Main(string[] args)
    {
        QueueUsingStacks queue = new QueueUsingStacks();

        // Enqueue elements
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        // Dequeue elements
        Console.WriteLine("Dequeued: " + queue.Dequeue()); // 10
        Console.WriteLine("Front Element: " + queue.Peek()); // 20
        Console.WriteLine("Dequeued: " + queue.Dequeue()); // 20
        Console.WriteLine("Dequeued: " + queue.Dequeue()); // 30

        Console.WriteLine("Is Queue Empty? " + queue.IsEmpty());
    }
}
