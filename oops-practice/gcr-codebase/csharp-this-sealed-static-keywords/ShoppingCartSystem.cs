using System;
class Product
{
    public static double Discount = 5;
    public string ProductName;
    public int Price;
    public int Quantity;

    public readonly int ProductID;

    public Product(int ProductID,string ProductName,int Price, int Quantity)
    {
        this.ProductID = ProductID;
        this.ProductName = ProductName;
        this.Price = Price;
        this.Quantity = Quantity;
    }
    public static void UpdateDiscount(int newDiscount)
    {
        Discount = newDiscount;
        Console.WriteLine("Update Discount:"+Discount);

    }

    public void DisplayDetails()
    {
        Console.WriteLine("Discount: "+Discount);
        Console.WriteLine("Product ID:"+ProductID);
        Console.WriteLine("Product Name:"+ProductName);
        Console.WriteLine("Price:"+Price);
        Console.WriteLine("Quantity:"+Quantity);
    }
}
class ShoppingCartSystem
{
    static void Main(string[] args)
    {
        Product p1 = new Product(125,"Books",1500,3);
        Product p2 = new Product(789,"Laptop",15000,1);

        if(p1 is Product)
        {
            Console.WriteLine("p1 is a Product object");
            p1.DisplayDetails();
        }

        Console.WriteLine();

        if(p2 is Product)
        {
            Console.WriteLine("p2 is a Product object");
            p2.DisplayDetails();
        }
        Console.WriteLine();

        Product.UpdateDiscount(8);

        Console.WriteLine();
        p1.DisplayDetails();
        Console.WriteLine();
        p2.DisplayDetails();
    }
}