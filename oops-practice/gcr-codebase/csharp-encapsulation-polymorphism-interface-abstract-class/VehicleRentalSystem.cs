using System;
//Interface
interface IInsurable
{
    double CalculateInsurance();
    string GetInsuranceDetails();
}
abstract class Vehicle
{
    private int vehicleNumber;
    private string vehicleType;
    private double rentalRate;

    public int VehicleNumber
    {
        get
        {
            return vehicleNumber;
        }
        set
        {
            vehicleNumber = value;
        }
    }

    public string VehicleType
    {
        get
        {
            return vehicleType;
        }
        set
        {
            vehicleType = value;
        }
    }

    public double RentalRate
    {
        get
        {
            return rentalRate;
        }
        set
        {
            rentalRate = value;
        }
    }

    public abstract double CalculateRentalCost(int days);

    public void DisplayDetails(int days)
    {
        Console.WriteLine("Vehicle Number: "+VehicleNumber);
        Console.WriteLine("Vehicle Type: "+VehicleType);
        Console.WriteLine("Rental Rate per Day: "+RentalRate);


        Console.WriteLine("Calculate Cost for: "+days+" days: "+CalculateRentalCost(days));
    }
}

class Car : Vehicle,IInsurable
{
    public override double CalculateRentalCost(int days)
    {
        return RentalRate * days;
    }

    public double CalculateInsurance()
    {
        return RentalRate * 0.1;    //10% of daily rate
    }

    public string GetInsuranceDetails()
    {
        return "Car Rental Cost: "+RentalRate+" And Car Insurance Cost: "+CalculateInsurance();
    }
}

class Bike : Vehicle,IInsurable
{
    public override double CalculateRentalCost(int days)
    {
        return RentalRate * days ;
    }

    public double CalculateInsurance()
    {
        return RentalRate * 0.2;    //20% of daily rate
    }

    public string GetInsuranceDetails()
    {
        return "Bike Rental Cost: "+RentalRate+" And Bike Insurance Cost: "+CalculateInsurance();
    }
}

class Truck : Vehicle,IInsurable
{
    public override double CalculateRentalCost(int days)
    {
        return RentalRate * days ;
    }

    public double CalculateInsurance()
    {
        return RentalRate * 0.15;    //15% of daily rate
    }

    public string GetInsuranceDetails()
    {
        return "Truck Rental Cost: "+RentalRate+" And Truck Insurance Cost: "+CalculateInsurance();
    }
}
class VehicleRentalSystem
{
    static void Main(string[] args)
    {
        //Array Of Vehicle
        Vehicle[] vehicles = new Vehicle[3];

        vehicles[0] = new Car();
        vehicles[0].VehicleNumber = 1234;
        vehicles[0].VehicleType = "Venue";
        vehicles[0].RentalRate = 5000;

        vehicles[1] = new Bike();
        vehicles[1].VehicleNumber = 9876;
        vehicles[1].VehicleType = "Passion Pro";
        vehicles[1].RentalRate = 8000;

        vehicles[2] = new Truck();
        vehicles[2].VehicleNumber = 4567;
        vehicles[2].VehicleType = "Truck 456";
        vehicles[2].RentalRate = 10000;

        for(int i = 0; i < vehicles.Length; i++)
        {
            Console.WriteLine("----------------------------------------------------------");
            vehicles[i].DisplayDetails(3);

            IInsurable insurable = (IInsurable)vehicles[i];
            Console.WriteLine(insurable.GetInsuranceDetails());
        }
    }
}