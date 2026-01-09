using System;
using System.Collections.Generic;

class SortStackUsingRecursion  // Main class
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(3);
        stack.Push(1);
        stack.Push(4);
        stack.Push(2);

        Console.WriteLine("Original Stack:");
        PrintStack(stack);

        SortStack(stack);

        Console.WriteLine("\nSorted Stack (Ascending Order):");
        PrintStack(stack);
    }

    static void SortStack(Stack<int> stack)
    {
        if (stack.Count == 0)   // Base case
            return;

        int top = stack.Pop();
        SortStack(stack);       // Recursive call
        InsertSorted(stack, top);
    }

    static void InsertSorted(Stack<int> stack, int element)
    {
        if (stack.Count == 0 || stack.Peek() <= element)
        {
            stack.Push(element);
            return;
        }

        int top = stack.Pop();
        InsertSorted(stack, element);
        stack.Push(top);
    }

    static void PrintStack(Stack<int> stack)
    {
        foreach (int item in stack)
        {
            Console.Write(item + " ");
        }
    }
}
