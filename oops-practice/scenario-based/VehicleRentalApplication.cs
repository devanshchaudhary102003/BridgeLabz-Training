using System;
//Interface
public interface IRentable
{
    double CalculateRent(int days);
}
class Vehicle:IRentable
{
    protected string VehicleNumber;
    protected double RentPerDay;
    protected string VehicleType;

    public Vehicle(string vehicleNumber,double rentPerDay,string vehicleType)
    {
        VehicleNumber = vehicleNumber;
        RentPerDay = rentPerDay;
        VehicleType = vehicleType;
    }

    public virtual double CalculateRent(int days)
    {
        return RentPerDay * days;
    }

    public string GetVehicleType()
    {
        return VehicleType;
    }
}

class Bike : Vehicle
{
    public Bike(string vehicleNumber):base(vehicleNumber,300,"Bike"){}

    public override double CalculateRent(int days)
    {
        return base.CalculateRent(days);
    }
}

class Car : Vehicle
{
    public Car(string vehicleNumber):base(vehicleNumber,800,"Car"){}

    public override double CalculateRent(int days)
    {
        return base.CalculateRent(days);
    }
}

class Truck : Vehicle
{
    public Truck(string vehicleNumber):base(vehicleNumber,2000,"Truck"){}

    public override double CalculateRent(int days)
    {
        
        return base.CalculateRent(days);
    }
}

class Customer
{
    public string Name { get; set; }

    public Customer(string name)
    {
        Name = name;
    }

    public void RentVehicle(Vehicle vehicle, int days)
    {
        double amount = vehicle.CalculateRent(days);
        Console.WriteLine(Name+" rented a "+vehicle.GetVehicleType()+" for "+days+" days ");
        Console.WriteLine("Total Rent: "+amount);
    }
}
class VehicleRentalApplication
{
    static void Main(string[] args)
    {
        Customer customer = new Customer("Devansh");

        Vehicle bike = new Bike("BIKE-101");
        Vehicle car = new Car("CAR-VENUE");
        Vehicle truck = new Truck("TRUCK-789");

        customer.RentVehicle(bike,2);
        Console.WriteLine();

        customer.RentVehicle(car,3);
        Console.WriteLine();

        customer.RentVehicle(truck,4);
    }
}