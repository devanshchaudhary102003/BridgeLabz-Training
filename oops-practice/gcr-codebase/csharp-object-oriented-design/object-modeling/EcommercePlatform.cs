using System;
class Product
{
    public string ProductName;
    public double Price;

    public Product(string productName,double price)
    {
        ProductName = productName;
        Price = price;
    }

    public void ShotProductDetails()
    {
        Console.WriteLine("Product Name: "+ProductName);
        Console.WriteLine("Product Price: "+Price);
    }
}

class Order
{
    public int OrderId;
    public Product[] Products;
    public int ProductCount = 0;

    public Order(int orderId,int maxProduct)
    {
        OrderId = orderId;
        Products = new Product[maxProduct];
    }

    public void AddProduct(Product product)
    {
        if(ProductCount < Products.Length)
        {
            Products[ProductCount++] = product;
            Console.WriteLine(product.ProductName + " added to Order "+OrderId);
        }
    }

    public void ShowOrderDetails()
    {
        Console.WriteLine("\n Order ID: "+OrderId);
        double total = 0;

        for(int i = 0; i < ProductCount; i++)
        {
            Console.WriteLine("- "+Products[i].ProductName+": Rs"+Products[i].Price);
            total += Products[i].Price;
        }
        Console.WriteLine("Total Amount: Rs"+total);
    }
}

class Customer
{
    public string CustomerName;
    public Order[] Orders;
    public int OrderCount = 0;

    public Customer(string customerName,int maxOrder)
    {
        CustomerName = customerName;
        Orders = new Order[maxOrder];
    }

    //Communication: Customer places Order
    public void PlaceOrder(Order order)
    {
        if(OrderCount < Orders.Length)
        {
            Orders[OrderCount++] = order;
            Console.WriteLine(CustomerName+" placed Order ID: "+order.OrderId);
        }
    }

    public void ShowCustomerOrders()
    {
        Console.WriteLine("Orders Placed By "+CustomerName+" :");
        for(int i = 0; i < OrderCount; i++)
        {
            Orders[i].ShowOrderDetails();
        }
    }
}
class EcommercePlatform
{
    static void Main(string[] args)
    {
        Customer customer = new Customer("Devansh",3);

        Product product1 = new Product("Laptop",55000);
        Product product2 = new Product("Mouse",500);
        Product product3 = new Product("Keyboard",5500);

        Order order1 = new Order(101,5);
        Order order2 = new Order(102,5);

        // Order contains products (Aggregation)
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        

        order2.AddProduct(product3);
        order2.AddProduct(product2);

        // Customer places orders (Communication)
        customer.PlaceOrder(order1);
        customer.PlaceOrder(order2);

        // Display
        customer.ShowCustomerOrders();
    }
}