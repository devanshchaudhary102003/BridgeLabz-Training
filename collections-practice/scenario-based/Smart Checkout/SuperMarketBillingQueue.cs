using System;
using System.Collections.Generic;

class Item
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Item(string name, decimal price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }
}

class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> CartItems { get; set; }     // List of item names

    public Customer(int id, string name, List<string> cartItems)
    {
        Id = id;
        Name = name;
        CartItems = cartItems;
    }
}
class SuperMarketBillingQueue
{
    static void Main(string[] args)
    {

        Dictionary<string, Item> inventory = new Dictionary<string, Item>(StringComparer.OrdinalIgnoreCase)
        {
            { "Milk", new Item("Milk", 45m, 10) },
            { "Bread", new Item("Bread", 35m, 20) },
            { "Eggs", new Item("Eggs", 60m, 60) },
            { "Chips", new Item("Chips", 25m, 50) }
        };

        // Queue of customers at one checkout counter
        Queue<Customer> checkoutQueue = new Queue<Customer>();
        while (true)
        {
            Console.WriteLine("\n=== SmartCheckout Menu ===");
            Console.WriteLine("1. Add Customer to Queue");
            Console.WriteLine("2. Serve Next Customer (Remove from Queue)");
            Console.WriteLine("3. View Queue");
            Console.WriteLine("4. View Inventory");
            Console.WriteLine("5. Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                AddCustomer(checkoutQueue);
            }
            else if (choice == "2")
            {
                ServeCustomer(checkoutQueue, inventory);
            }
            else if (choice == "3")
            {
                ViewQueue(checkoutQueue);
            }
            else if (choice == "4")
            {
                ViewInventory(inventory);
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }

    static void AddCustomer(Queue<Customer> queue)
    {
        Console.WriteLine("Enter Customer Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Customer Name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter items (Milk, Bread, Eggs): ");
        string input = Console.ReadLine();

        List<string> items = new List<string>();
        string[] arr = input.Split(',');

        foreach (string item in arr)
        {
            items.Add(item.Trim());
        }

        queue.Enqueue(new Customer(id,name,items));
        Console.WriteLine("Customer added to queue.");
    }

    static void ServeCustomer(Queue<Customer> queue, Dictionary<string, Item> inventory)
    {
        if(queue.Count == 0)
        {
            Console.WriteLine("No Customers in queue.");
            return;
        }

        Customer c = queue.Dequeue();
        Console.WriteLine("\nServing Customer: "+c.Name+" (ID: "+c.Id+")");

        decimal total = 0;

        foreach(string itemName in c.CartItems)
        {
            if (!inventory.ContainsKey(itemName))
            {
                Console.WriteLine(itemName+" not found.");
                continue;
            }

            Item item = inventory[itemName];

            if(item.Stock > 0)
            {
                item.Stock--;
                total += item.Price;
                Console.WriteLine(item.Name+" : Rs "+item.Price+" | Stock Left: "+item.Stock);
            }
            else
            {
                Console.WriteLine(item.Name+ "is OUT OF STOCK");
            }
        }

        Console.WriteLine("Total Bill: Rs "+total);
    }

    static void ViewQueue(Queue<Customer> queue)
    {
        if(queue.Count == 0)
        {
            Console.WriteLine("Queue is empty.");
            return;
        }

        Console.WriteLine("\nCustomers in Queue: ");

        foreach(Customer c in queue)
        {
            Console.WriteLine(c.Id+" - "+c.Name);
        }
    }

    static void ViewInventory(Dictionary<string, Item> inventory)
    {
        Console.WriteLine("\nInventory Details: ");
        foreach(var pair in inventory)
        {
            Item item = pair.Value;
            Console.WriteLine(item.Name+" | Price: Rs "+item.Price+" | Stock: "+item.Stock);
        }
    }
}