using System;
using System.Collections.Generic;
using System.Data.Common;

class Category
{
    public string CategoryName;
}

class BookCategory : Category
{
    public BookCategory()
    {
        CategoryName = "Book";
    }
}

class ClothingCategory : Category
{
    public ClothingCategory()
    {
        CategoryName = "Clothing";
    }
}

class Product<T> where T : Category
{
    public string Name;
    public double Price;
    public T Category;

    public Product(string name, double price, T category)
    {
        Name = name;
        Price = price;
        Category = category;
    }

    public void Display()
    {
        Console.WriteLine("Product Name: "+Name+" Price: "+Price+" Category: "+Category);
    }
} 

class DiscountService
{
    public static void ApplyDiscount<T>(Product<T> product, double percentage) where T : Category
    {
        product.Price = product.Price - (product.Price * percentage / 100);
    }
}

class MarketPlaceCatalog<T> where T : Category
{
    private List<Product<T>> products = new List<Product<T>>();

    public void AddProduct(Product<T> product)
    {
        products.Add(product);
    }

    public void ShowCatalog()
    {
        Console.WriteLine("\n------ MarketPlace Catalog --------");
        for(int i = 0; i < products.Count; i++)
        {
            products[i].Display();
        }
    }
}
class DynamicOnlineMarketplace
{
    static void Main(string[] args)
{
    // Categories
    BookCategory bookCategory = new BookCategory();
    ClothingCategory clothingCategory = new ClothingCategory();

    // Products
    Product<BookCategory> book = new Product<BookCategory>("C# Programming", 500, bookCategory);
    Product<ClothingCategory> shirt = new Product<ClothingCategory>("T-Shirt", 1000, clothingCategory);

    //Catalog Separate catalogs (type-safe)
    MarketPlaceCatalog<BookCategory> bookCatalog = new MarketPlaceCatalog<BookCategory>();
    MarketPlaceCatalog<ClothingCategory> clothingCatalog = new MarketPlaceCatalog<ClothingCategory>();

    bookCatalog.AddProduct(book);
    clothingCatalog.AddProduct(shirt);

    // Before Discount
    bookCatalog.ShowCatalog();
    clothingCatalog.ShowCatalog();

    // Apply Discount
    DiscountService.ApplyDiscount(book, 10);
    DiscountService.ApplyDiscount(shirt, 20);

    // After Discount
    bookCatalog.ShowCatalog();
    clothingCatalog.ShowCatalog();
    }
}