using System;
public class Product
{
    //Instance Variable
    public string ProductName;
    public double Price;
    
    //class Variable(static)
    static int totalProducts;

    //construtor
    public Product(string productName,double price)
    {
        ProductName = productName;
        Price = price;
        totalProducts++; //Increment whenever object is created
    }
    //Instance Method
    public void DisplayProductDetails()
    {
        Console.WriteLine("Product Name:"+ProductName);
        Console.WriteLine("Price of that Product:"+Price);
        Console.WriteLine();
    }

    //Class Method(static)
    public static void DisplayTotalProducts()
    {
        Console.WriteLine("Total Products Created: "+totalProducts);
    }
}
public class ProductInventory
{
    static void Main(string[] args)
    {
        Product p1 = new Product("Laptop",55000);
        Product p2 = new Product("Mobile",45000);
        Product p3 = new Product("HeadPhones",1200);

        p1.DisplayProductDetails();
        p2.DisplayProductDetails();
        p3.DisplayProductDetails();

        Product.DisplayTotalProducts();
    }
}