using System;
public class CarRental
{
    public string CustomerName;
    public string CarModel;
    public int RentalDays;

    public CarRental(string customerName,string carModel,int rentalDays)
    {
        CustomerName = customerName;
        CarModel = carModel;
        RentalDays = rentalDays;
    }
    public void DisplayDetails()
    {
        Console.WriteLine("--------------------- Car Details ---------------------");
        Console.WriteLine("Customer Name:"+CustomerName);
        Console.WriteLine("Car Model:"+CarModel);
        Console.WriteLine("Rental Days:"+RentalDays);
    }

    public void totalCost()
    {
        int costPerDay = 4500;
        int totalCost = costPerDay * RentalDays;
        Console.WriteLine("Total Cost:"+totalCost);
    }
}
public class CarRentalSystem
{
    static void Main(string[] args)
    {
        Console.Write("Enter Customer Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Car Model: ");
        string model = Console.ReadLine();

        Console.Write("Enter Rental Days: ");
        int days = int.Parse(Console.ReadLine());

        CarRental car = new CarRental(name,model,days);
        car.DisplayDetails();

        car.totalCost();
    }
}