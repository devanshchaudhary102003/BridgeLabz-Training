using System;
interface IGPS
{
    string GetCurrentLocation();
    void UpdateLocation(string newLocation);
}
abstract class Vehicle:IGPS
{
    //Private fields (Encapsulation)
    private int vehicleId;
    private string driverName;
    private int ratePerKm;
    private string currentLocation;

    public int VehicleId
    {
        get
        {
            return vehicleId;
        }
        set
        {
            vehicleId = value;
        }
    }

    public string DriverName
    {
        get
        {
            return driverName;
        }
        set
        {
            driverName = value;
        }
    }

    public int RatePerKm
    {
        get
        {
            return ratePerKm;
        }
        set
        {
            ratePerKm = value;
        }
    }

    public abstract double CalculateFare(double distance);

    public void GetVehicleDetails()
    {
        Console.WriteLine("Vehicle Id: "+vehicleId);
        Console.WriteLine("Driver Name: "+driverName);
        Console.WriteLine("Rate per KM: "+ratePerKm);
        Console.WriteLine("Current Location: "+currentLocation);
    }

    //interface implementation
    public string GetCurrentLocation()
    {
        return currentLocation;
    }

    public void UpdateLocation(string newLocation)
    {
        currentLocation = newLocation;
    }
}
class Car : Vehicle
{
    public override double CalculateFare(double distance)
    {
        return distance * RatePerKm;
    }
}

class Bike : Vehicle
{
    public override double CalculateFare(double distance)
    {
        return distance * RatePerKm;
    }
}

class Auto : Vehicle
{
    public override double CalculateFare(double distance)
    {
        return distance * RatePerKm;
    }
}
class RideHallingApplication
{
    static void Main(string[] args)
    {
        Vehicle[] vehicle = new Vehicle[3];

        vehicle[0] = new Car();
        vehicle[0].VehicleId = 101;
        vehicle[0].DriverName = "Devansh";
        vehicle[0].RatePerKm = 150;
        vehicle[0].UpdateLocation("Township");

        vehicle[1] = new Bike();
        vehicle[1].VehicleId = 102;
        vehicle[1].DriverName = "Rohit";
        vehicle[1].RatePerKm = 90;
        vehicle[1].UpdateLocation("Vrindavan");

        vehicle[2] = new Auto();
        vehicle[2].VehicleId = 103;
        vehicle[2].DriverName = "Krishna Sharma";
        vehicle[2].RatePerKm = 50;
        vehicle[2].UpdateLocation("Goverdhan");

        double distance = 10;

        for(int i = 0; i < vehicle.Length; i++)
        {
            vehicle[i].GetVehicleDetails();
            Console.WriteLine("Distance: "+distance+" km");
            Console.WriteLine("Total Fare: "+vehicle[i].CalculateFare(distance));
            Console.WriteLine("-------------------------------------------");
        }
    }
}
