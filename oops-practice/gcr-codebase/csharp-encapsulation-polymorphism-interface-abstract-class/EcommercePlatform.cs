using System;
//Interface
interface ITaxable
{
    double CalculateTax();
    string GetTaxDetails();
}
abstract class Product
{
    private int productId;
    private string name;
    private int price;

    public int ProductId
    {
        get
        {
            return productId;
        }
        set
        {
            productId = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public int Price
    {
        get
        {
            return price;
        }
        set
        {
            if(value > 0)
                price = value;
        }
    }

     // Abstract method for discount
    public abstract double CalculateDiscount();

    // Final Price Calculation (Polymorphic)
    public virtual double CalculateTax()
    {
        return 0;
    }

    public double CalculateFinalPrice()
    {
        return Price + CalculateTax() - CalculateDiscount();
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Product Id: "+ProductId);
        Console.WriteLine("Product Name: "+Name);
        Console.WriteLine("Base Price: "+Price);


        Console.WriteLine("Tax          : " + CalculateTax());
        Console.WriteLine("Discount     : " + CalculateDiscount());
        Console.WriteLine("Final Price  : " + CalculateFinalPrice());
        Console.WriteLine("------------------------------------");
    }
}

class Electronics : Product,ITaxable
{

    public override double CalculateDiscount()
    {
        return Price * 0.10;    //10 % discount
    }

    public override double CalculateTax()
    {
        return Price * 0.18;    //18% tax
    }

    public string GetTaxDetails()
    {
        return "Electronics Tax: 18%";
    }
}

class Clothing : Product,ITaxable{
    public override double CalculateDiscount()
    {
        return Price * 0.20;    //20% discount
    }

    public override double CalculateTax()
    {
        return Price * 0.24;    //24% Tax
    }

    public string GetTaxDetails()
    {
        return "Clothing Tax: 24%";
    }
}

class Groceries : Product,ITaxable{
    public override double CalculateDiscount()
    {
        return Price * 0.10;    //10% discount
    }

    public override double CalculateTax()
    {
        return Price * 0.14;    //14% Tax
    }

    public string GetTaxDetails()
    {
        return "Clothing Tax: 14%";
    }
}
class EcommercePlatform
{
    static void Main(string[] args)
    {
        // Array of products
        Product[] products = new Product[3];

        products[0] = new Electronics();
        products[0].ProductId = 101;
        products[0].Name = "Laptop";
        products[0].Price = 60000;

        products[1] = new Clothing();
        products[1].ProductId = 102;
        products[1].Name = "Jacket";
        products[1].Price = 40000;

        products[2] = new Groceries();
        products[2].ProductId = 103;
        products[2].Name = "Rice";
        products[2].Price = 1200;

        for(int i = 0; i < products.Length; i++)
        {
            products[i].DisplayDetails();
        }
    }
}