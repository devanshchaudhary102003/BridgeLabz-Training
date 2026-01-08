/*4. Singly Linked List: Inventory Management System
Problem Statement: Design an inventory management system 
using a singly linked list where each node stores information 
about an item such as Item Name, Item ID, Quantity, and 
Price. Implement the following functionalities:

Add an item at the beginning, end, or at a specific position.
Remove an item based on Item ID.
Update the quantity of an item by Item ID.
Search for an item based on Item ID or Item Name.
Calculate and display the total value of inventory (Sum of Price * Quantity for each item).
Sort the inventory based on Item Name or Price in ascending or descending order.
*/
using System;
//Node Class
class ItemNode{
    public string ItemName;
    public int ItemId;
    public int Quantity;
    public double Price;
    public ItemNode Next;

    public ItemNode(string ItemName, int ItemId, int Quantity, double Price)
    {
        this.ItemName = ItemName;
        this.ItemId = ItemId;
        this.Quantity = Quantity;
        this.Price = Price;
        Next = null;
    }
}

//Singly Linked List
class ItemLinkedList
{
    private ItemNode Head;

    //At the Beginning
    public void AddAtBeginning(string ItemName, int ItemId, int Quantity, double Price)
    {
        ItemNode newNode = new ItemNode(ItemName,ItemId,Quantity,Price);

        newNode.Next = Head;
        Head = newNode;
        Console.WriteLine("Item added at beginning");
    }

    //At the end
    public void AddAtEnd(string ItemName, int ItemId, int Quantity, double Price)
    {
        ItemNode newNode = new ItemNode(ItemName,ItemId,Quantity,Price);

        if(Head == null)
        {
            Head = newNode;
            Console.WriteLine("Item added at end");
            return;
        }

        ItemNode temp = Head;
        while(temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = newNode;
        Console.WriteLine("Item added at end");
    }

    public void AddAtPosition(int Position,string ItemName, int ItemId, int Quantity, double Price)
    {
        if(Position <= 0)
        {
            Console.WriteLine("Invalid Position....");
            return;
        }
        if(Position == 1)
        {
            AddAtBeginning(ItemName,ItemId,Quantity,Price);
            return;
        }

        ItemNode newNode = new ItemNode(ItemName,ItemId,Quantity,Price);
        ItemNode temp = Head;

        for(int i = 1 ; i < Position - 1 && temp != null ; i++)
        {
            temp = temp.Next;
        }

        if(temp == null)
        {
            Console.WriteLine("Position out of range.");
            return;
        }

        newNode.Next = temp.Next;
        temp.Next = newNode;

        Console.WriteLine("Item added at position "+Position);
    }
    public void DeleteByItemId(int ItemId)
    {
        if(Head == null)
        {
            Console.WriteLine("List is Empty.");
            return;
        }

        if(Head.ItemId == ItemId)
        {
            Head = Head.Next;
            Console.WriteLine("Item Deleted.");
            return;
        }

        ItemNode temp = Head;
        while(temp.Next != null && temp.Next.ItemId != ItemId)
        {
            temp = temp.Next;
        }

        if(temp.Next == null)
        {
            Console.WriteLine("Item Not Found....");
        }
        else
        {
            temp.Next = temp.Next.Next;
            Console.WriteLine("Item Deleted");
        }
    }

    //Search By ItemId
    public void SearchByItemId(int ItemId)
    {
        ItemNode temp = Head;

        while(temp != null)
        {
            if(temp.ItemId == ItemId)
            {
                Console.WriteLine("Item Found: ");
                Console.WriteLine("Item Name: "+temp.ItemName);
                Console.WriteLine("Item Id: "+temp.ItemId);
                Console.WriteLine("Quantity: "+temp.Quantity);
                Console.WriteLine("Price: "+temp.Price);
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Item Not Found");
    }

    //Search By ItemName
    public void SearchByItemName(string ItemName)
    {
        ItemNode temp = Head;

        while(temp != null)
        {
            if(temp.ItemName == ItemName)
            {
                Console.WriteLine("Item Found: ");
                Console.WriteLine("Item Name: "+temp.ItemName);
                Console.WriteLine("Item Id: "+temp.ItemId);
                Console.WriteLine("Quantity: "+temp.Quantity);
                Console.WriteLine("Price: "+temp.Price);
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Item Not Found");
    }

    //Update the quantity of an item by Item ID.
    public void UpdateQuantity(int ItemId, int newQuantity)
    {
        ItemNode temp = Head;

        while(temp != null)
        {
            if(temp.ItemId == ItemId)
            {
                temp.Quantity = newQuantity;
                Console.WriteLine("Quantity Updated Successfully");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Item Not Found");
    }

    //Total Inventory Value
    public void CalculateTotalValue()
    {
        double total = 0;
        ItemNode temp = Head;

        while(temp != null)
        {
            total += temp.Price * temp.Quantity;
            temp = temp.Next;
        }
        Console.WriteLine("Total Inventory Value: "+total);
    }

    public void SortByPriceAscending()
    {
        for(ItemNode i = Head; i != null; i = i.Next)
        {
            for(ItemNode j = i.Next; j != null; j = j.Next)
            {
                if(i.Price > j.Price)
                {
                    Swap(i,j);
                }
            }
        }
        Console.WriteLine("Inventory sorted by price (Ascending)");
    }

    //Swap data
    private void Swap(ItemNode a, ItemNode b)
    {
        string name = a.ItemName;
        int id = a.ItemId;
        int quantity = a.Quantity;
        double price = a.Price;

        a.ItemName = b.ItemName;
        a.ItemId = b.ItemId;
        a.Quantity = b.Quantity;
        a.Price = b.Price;

        b.ItemName = name;
        b.ItemId = id;
        b.Quantity = quantity;
        b.Price = price;
    }

    //Display all Items
    public void Display()
    {
        ItemNode temp = Head;
        while(temp != null)
        {
            DisplayItem(temp);
            temp = temp.Next;
        }
    }

    private void DisplayItem(ItemNode temp)
    {
        Console.WriteLine("-------------------");
        Console.WriteLine("Item Name: " + temp.ItemName);
        Console.WriteLine("Item Id: " + temp.ItemId);
        Console.WriteLine("Quantity: " + temp.Quantity);
        Console.WriteLine("Price: " + temp.Price);
    }
}
class InventoryManagementSystem
{
    static void Main(string[] args)
{
    ItemLinkedList inventory = new ItemLinkedList();

    inventory.AddAtBeginning("Pen", 101, 50, 10);
    inventory.AddAtEnd("Book", 102, 20, 100);
    inventory.AddAtPosition(2, "Pencil", 103, 100, 5);

    Console.WriteLine("\nAll Inventory Items:");
    inventory.Display();

    Console.WriteLine("\nSearch Item by ID 102:");
    inventory.SearchByItemId(102);

    Console.WriteLine("\nSearch Item by Name 'Pen':");
    inventory.SearchByItemName("Pen");

    Console.WriteLine("\nUpdate Quantity of Item ID 101:");
    inventory.UpdateQuantity(101, 60);

    Console.WriteLine("\nDelete Item ID 103:");
    inventory.DeleteByItemId(103);

    Console.WriteLine("\nTotal Inventory Value:");
    inventory.CalculateTotalValue();

    Console.WriteLine("\nSort Inventory by Price (Ascending):");
    inventory.SortByPriceAscending();
    inventory.Display();
    }
}