/*Story 1: Metal Factory Pipe Cutting
Context: Maximize revenue from cutting metal rods of different sizes and values.
Scenario A: Given a rod of length 8 and price chart for different lengths, find best
cuts.
Scenario B: Add a custom-length order and check impact on revenue.
Scenario C: Visualize revenue if cut strategy is not optimized.*/
using System;

// PriceItem Class
class PriceItem
{
    private int length;
    private int price;

    public int Length
    {
        get { 
            return length; 
        }
        set { 
            length = value; 
        }
    }

    public int Price
    {
        get { 
            return price; 
        }
        set { 
            price = value; 
        }
    }
}

// PriceCatalog Class
class PriceCatalog
{
    private PriceItem[] items = new PriceItem[8];

    public void Initialize()
    {
        items[0] = new PriceItem();
        items[0].Length = 1;
        items[0].Price = 1;

        items[1] = new PriceItem();
        items[1].Length = 2;
        items[1].Price = 5;

        items[2] = new PriceItem();
        items[2].Length = 3;
        items[2].Price = 8;

        items[3] = new PriceItem();
        items[3].Length = 4;
        items[3].Price = 9;

        items[4] = new PriceItem();
        items[4].Length = 5;
        items[4].Price = 10;

        items[5] = new PriceItem();
        items[5].Length = 6;
        items[5].Price = 17;

        items[6] = new PriceItem();
        items[6].Length = 7;
        items[6].Price = 17;

        items[7] = new PriceItem();
        items[7].Length = 8;
        items[7].Price = 20;
    }

    public int GetPrice(int length)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].Length == length)
                return items[i].Price;
        }
        return 0;
    }

    public void SetPrice(int length, int newPrice)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].Length == length)
            {
                items[i].Price = newPrice;
                break;
            }
        }
    }
}

// Rod Class
class Rod
{
    private int length;

    public int Length
    {
        get { 
            return length; 
        }
        set { 
            length = value; 
        }
    }
}

// Factory Class
class Factory
{
    protected PriceCatalog catalog;

    public void SetCatalog(PriceCatalog catalog)
    {
        this.catalog = catalog;
    }

    public virtual int GetMaxRevenue(Rod rod)
    {
        int maxRevenue = 0;

        for (int i = 1; i <= rod.Length; i++)
        {
            int remaining = rod.Length - i;
            int revenue = catalog.GetPrice(i);

            if (remaining > 0)
            {
                revenue += catalog.GetPrice(remaining);
            }

            if (revenue > maxRevenue)
            {
                maxRevenue = revenue;
            }
        }

        return maxRevenue;
    }

    public int GetNonOptimizedRevenue(Rod rod)
    {
        return catalog.GetPrice(rod.Length);
    }
}

// Inheritance + Polymorphism
class PremiumFactory : Factory
{
    public override int GetMaxRevenue(Rod rod)
    {
        Console.WriteLine("Premium Factory Calculation...");
        return base.GetMaxRevenue(rod);
    }
}

// Main Program
class MetalFactoryPipeCutting
{
    static void Main()
    {
        // Price Catalog
        PriceCatalog catalog = new PriceCatalog();
        catalog.Initialize();

        // Rod
        Rod rod = new Rod();
        rod.Length = 8;

        // Factory
        Factory factory = new PremiumFactory();
        factory.SetCatalog(catalog);

        // Scenario A
        Console.WriteLine("Scenario A: Best Revenue");
        Console.WriteLine(factory.GetMaxRevenue(rod));

        // Scenario B
        Console.WriteLine("\nScenario B: Custom Price (Length 3 -> 12)");
        catalog.SetPrice(3, 12);
        Console.WriteLine(factory.GetMaxRevenue(rod));

        // Scenario C
        Console.WriteLine("\nScenario C: Non Optimized Revenue");
        Console.WriteLine(factory.GetNonOptimizedRevenue(rod));
    }
}
