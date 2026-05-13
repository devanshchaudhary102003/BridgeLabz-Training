using System;

class HashNode
{
    public int Key;
    public int Value;
    public HashNode Next;

    public HashNode(int key, int value)
    {
        Key = key;
        Value = value;
        Next = null;
    }
}

class CustomHashMap
{
    private HashNode[] buckets;
    private int size;

    public CustomHashMap(int size)
    {
        this.size = size;
        buckets = new HashNode[size];
    }

    private int GetIndex(int key)
    {
        return Math.Abs(key) % size;
    }

    public void Put(int key, int value)
    {
        int index = GetIndex(key);
        HashNode head = buckets[index];

        if (head == null)
        {
            buckets[index] = new HashNode(key, value);
            return;
        }

        HashNode current = head;
        while (current != null)
        {
            if (current.Key == key)
            {
                current.Value = value; // Update
                return;
            }

            if (current.Next == null)
                break;

            current = current.Next;
        }

        current.Next = new HashNode(key, value);
    }

    public int Get(int key)
    {
        int index = GetIndex(key);
        HashNode current = buckets[index];

        while (current != null)
        {
            if (current.Key == key)
                return current.Value;

            current = current.Next;
        }

        return -1; // Not found
    }

    public void Remove(int key)
    {
        int index = GetIndex(key);
        HashNode current = buckets[index];
        HashNode prev = null;

        while (current != null)
        {
            if (current.Key == key)
            {
                if (prev == null)
                    buckets[index] = current.Next;
                else
                    prev.Next = current.Next;
                return;
            }

            prev = current;
            current = current.Next;
        }
    }

    public void Display()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write("Bucket " + i + ": ");
            HashNode current = buckets[i];

            while (current != null)
            {
                Console.Write("[" + current.Key + "," + current.Value + "] -> ");
                current = current.Next;
            }

            Console.WriteLine("null");
        }
    }
}

class CustomHashmap
{
    static void Main(string[] args)
    {
        Console.Write("Enter size of HashMap: ");
        int size = int.Parse(Console.ReadLine());

        CustomHashMap map = new CustomHashMap(size);

        while (true)
        {
            Console.WriteLine("\n--- HashMap Menu ---");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Get");
            Console.WriteLine("3. Remove");
            Console.WriteLine("4. Display");
            Console.WriteLine("5. Exit");
            Console.Write("Choose option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter key: ");
                    int key = int.Parse(Console.ReadLine());
                    Console.Write("Enter value: ");
                    int value = int.Parse(Console.ReadLine());
                    map.Put(key, value);
                    Console.WriteLine("Inserted successfully");
                    break;

                case 2:
                    Console.Write("Enter key: ");
                    key = int.Parse(Console.ReadLine());
                    int result = map.Get(key);
                    if (result == -1)
                        Console.WriteLine("Key not found");
                    else
                        Console.WriteLine("Value: " + result);
                    break;

                case 3:
                    Console.Write("Enter key: ");
                    key = int.Parse(Console.ReadLine());
                    map.Remove(key);
                    Console.WriteLine("Key removed if existed");
                    break;

                case 4:
                    map.Display();
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
