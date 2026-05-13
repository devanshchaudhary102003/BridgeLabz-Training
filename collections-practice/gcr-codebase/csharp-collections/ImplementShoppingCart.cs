using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

class ShoppingCart
{
    // 1) Store product prices (fast lookup)
    private Dictionary<string, double> productPrices = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);

    // 2) Maintain insertion order (LinkedDictionary behavior)
    private OrderedDictionary orderedCart = new OrderedDictionary();

    public void AddProduct(string product, double price)
    {
        if (string.IsNullOrWhiteSpace(product) || price <= 0)
        {
            Console.WriteLine("Invalid product or price.");
            return;
        }

        if (!productPrices.ContainsKey(product))
        {
            productPrices.Add(product, price);
            orderedCart.Add(product, price);

            Console.WriteLine("Product added: " + product + " Price: " + price);
        }
        else
        {
            Console.WriteLine("Product already exists.");
        }
    }

    // 3) Display products in insertion order
    public void DisplayCartInOrder()
    {
        Console.WriteLine("\n--- Cart Items (Insertion Order) ---");

        foreach (DictionaryEntry entry in orderedCart)
        {
            Console.WriteLine(entry.Key + " : " + entry.Value);
        }
    }

    // 4) Display products sorted by price
    public void DisplayCartSortedByPrice()
    {
        // Price → List of products (to handle same price items)
        SortedDictionary<double, List<string>> sortedByPrice =
            new SortedDictionary<double, List<string>>();

        foreach (KeyValuePair<string, double> pair in productPrices)
        {
            if (!sortedByPrice.ContainsKey(pair.Value))
            {
                sortedByPrice[pair.Value] = new List<string>();
            }
            sortedByPrice[pair.Value].Add(pair.Key);
        }

        Console.WriteLine("\n--- Cart Items (Sorted by Price) ---");

        foreach (KeyValuePair<double, List<string>> pair in sortedByPrice)
        {
            foreach (string product in pair.Value)
            {
                Console.WriteLine(product + " : " + pair.Key);
            }
        }
    }
}

class ImplementShoppingCart
{
    static void Main()
    {
        ShoppingCart cart = new ShoppingCart();

        cart.AddProduct("Laptop", 75000);
        cart.AddProduct("Mouse", 500);
        cart.AddProduct("Keyboard", 1500);
        cart.AddProduct("Monitor", 12000);

        cart.DisplayCartInOrder();
        cart.DisplayCartSortedByPrice();
    }
}
