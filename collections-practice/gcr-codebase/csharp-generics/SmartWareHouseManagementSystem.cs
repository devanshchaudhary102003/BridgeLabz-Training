using System;
using System.Collections.Generic;

//---------------- Abstract Class ----------------
abstract class WareHouseItem
{
    public string Name;
    
    public WareHouseItem(string name)
    {
        Name = name;
    }

    public abstract void DisplayInfo();
}

// ---------- DERIVED CLASSES ----------
class Electronics : WareHouseItem
{
    public Electronics(string name):base(name){ }

    public override void DisplayInfo()
    {
        Console.WriteLine("Electronic Item Name: "+Name);
    }
}

class Groceries : WareHouseItem
{
    public Groceries(string name):base(name){ }

    public override void DisplayInfo()
    {
        Console.WriteLine("Groceries Name: "+Name);
    }
}

class Furniture : WareHouseItem
{
    public Furniture(string name):base(name){ }

    public override void DisplayInfo()
    {
        Console.WriteLine("Furniture Name: "+Name);
    }
}

//----------------- Generics Storage Class -----------------
class Storage<T> where T : WareHouseItem
{
    private List<T> items = new List<T>();

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void DisplayItems()
    {
        for(int i = 0; i < items.Count; i++)
        {
            items[i].DisplayInfo();
        }
    }
}
class SmartWareHouseManagementSystem
{
    static void Main(string[] args)
    {
        Storage<Electronics> electronicsStorage = new Storage<Electronics>();
        electronicsStorage.AddItem(new Electronics("Laptop"));
        electronicsStorage.AddItem(new Electronics("Mobile"));

        Storage<Groceries> groceriesStorage = new Storage<Groceries>();
        groceriesStorage.AddItem(new Groceries("Rice"));
        groceriesStorage.AddItem(new Groceries("Milk"));

        Storage<Furniture> furnitureStorage = new Storage<Furniture>();
        furnitureStorage.AddItem(new Furniture("Chair"));
        furnitureStorage.AddItem(new Furniture("Table"));

        Console.WriteLine("=============Electronics Items==============");
        electronicsStorage.DisplayItems();

        Console.WriteLine("=============Groceries Items==============");
        groceriesStorage.DisplayItems();

        Console.WriteLine("=============Furnitures Items==============");
        furnitureStorage.DisplayItems();
    }
}