using System;

// Node class
class TextStateNode
{
    public string Content;
    public TextStateNode prev;
    public TextStateNode next;

    public TextStateNode(string content)
    {
        Content = content;
        prev = null;
        next = null;
    }
}

// Doubly Linked List for Undo/Redo
class UndoRedoManager
{
    private TextStateNode head;
    private TextStateNode tail;
    private TextStateNode current;
    private int size = 0;
    private int maxSize = 10;

    // Add new state
    public void AddState(string content)
    {
        TextStateNode newNode = new TextStateNode(content);

        // Remove all redo states
        if (current != null && current.next != null)
        {
            current.next.prev = null;
            current.next = null;
            tail = current;
        }

        if (head == null)
        {
            head = tail = current = newNode;
            size = 1;
        }
        else
        {
            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
            current = newNode;
            size++;
        }

        // Limit history size
        if (size > maxSize)
        {
            head = head.next;
            head.prev = null;
            size--;
        }
    }

    // Undo
    public void Undo()
    {
        if (current != null && current.prev != null)
        {
            current = current.prev;
        }
        else
        {
            Console.WriteLine("No more undo available.");
        }
    }

    // Redo
    public void Redo()
    {
        if (current != null && current.next != null)
        {
            current = current.next;
        }
        else
        {
            Console.WriteLine("No more redo available.");
        }
    }

    // Display current state
    public void DisplayCurrentState()
    {
        if (current != null)
        {
            Console.WriteLine("Current Text: " + current.Content);
        }
        else
        {
            Console.WriteLine("Text is empty.");
        }
    }
}

// Main class
class UndoRedoFunctionalityforTextEditor
{
    static void Main(string[] args)
    {
        UndoRedoManager editor = new UndoRedoManager();

        editor.AddState("H");
        editor.AddState("He");
        editor.AddState("Hel");
        editor.AddState("Hell");
        editor.AddState("Hello");

        editor.DisplayCurrentState();

        Console.WriteLine("\nUndo:");
        editor.Undo();
        editor.DisplayCurrentState();

        editor.Undo();
        editor.DisplayCurrentState();

        Console.WriteLine("\nRedo:");
        editor.Redo();
        editor.DisplayCurrentState();

        Console.WriteLine("\nAdd new text after undo:");
        editor.AddState("Hello World");
        editor.DisplayCurrentState();

        Console.WriteLine("\nTry redo:");
        editor.Redo();
    }
}
