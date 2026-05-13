using System;
interface IDiscountable
{
    double ApplyDiscount();
    string GetDiscountDetails();
}
abstract class FoodItem
{
    private string itemName;
    private double price;
    private int quantity;

    public string ItemName
    {
        get
        {
            return itemName;
        }
        set
        {
            itemName = value;
        }
    }

    public double Price
    {
        get
        {
            return price;
        }
        set
        {
            price = value;
        }
    }

    public int Quantity
    {
        get
        {
            return quantity;
        }
        set
        {
            quantity = value;
        }
    }

    public abstract double CalculateTotalPrice();

    public void GetItemDetails()
    {
        Console.WriteLine("Item Name: "+itemName);
        Console.WriteLine("Price of the Item: "+price);
        Console.WriteLine("Quantity: "+quantity);
        Console.WriteLine("Calculate Total Price: "+CalculateTotalPrice());
    }
}

class VegItem : FoodItem,IDiscountable
{
    public override double CalculateTotalPrice()
    {
        return Price*Quantity;  //No extra charge
    }

    public double ApplyDiscount()
    {
        return CalculateTotalPrice() * 0.10;    //10% discount
    }

    public string GetDiscountDetails()
    {
        return "Veg Item Dicount: 10%";
    }
}

class NonVegItem : FoodItem,IDiscountable
{
    public override double CalculateTotalPrice()
    {
        double extraCharge = 50;    //Non-veg Extra charge
        return (Price * Quantity) + extraCharge;
    }

    public double ApplyDiscount()
    {
        return CalculateTotalPrice() * 0.05;    //5% discount
    }

    public string GetDiscountDetails()
    {
        return "Non-Veg Item Discount: 5%";
    }
}
class OnlineFoodDeliverySystem
{
    static void Main(string[] args)
    {
        FoodItem[] foodItem = new FoodItem[2];

        foodItem[0] = new VegItem();
        foodItem[0].ItemName = "Veg Burger";
        foodItem[0].Price = 100;
        foodItem[0].Quantity = 2;

        foodItem[1] = new NonVegItem();
        foodItem[1].ItemName = "Chicken Tikka";
        foodItem[1].Price = 200;
        foodItem[1].Quantity = 2;

        for(int i = 0; i < foodItem.Length; i++)
        {
            foodItem[i].GetItemDetails();

            IDiscountable discount = (IDiscountable)foodItem[i];
            Console.WriteLine(discount.GetDiscountDetails());
            Console.WriteLine("Discount Amount: "+discount.ApplyDiscount());
            Console.WriteLine("Final Price: "+(foodItem[i].CalculateTotalPrice() - discount.ApplyDiscount()));
            Console.WriteLine("--------------------------------------------------------------");
        }
    }
}