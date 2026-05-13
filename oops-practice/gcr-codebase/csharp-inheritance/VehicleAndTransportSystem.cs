using System;
class Vehicle
{
    public int MaxSpeed;
    public string FuelType;

    public Vehicle(int maxSpeed,string fuelType)
    {
        MaxSpeed = maxSpeed;
        FuelType = fuelType;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine("Max Speed :"+MaxSpeed);
        Console.WriteLine("Fuel Type: "+FuelType);
    }
}

class Car : Vehicle
{
    public int SeatCapacity;

    public Car(int maxSpeed,string fuelType,int seatCapacity) : base(maxSpeed, fuelType)
    {
        SeatCapacity = seatCapacity;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("Car Details: ");
        base.DisplayDetails();
        Console.WriteLine("Seat Capacity: "+SeatCapacity);
        Console.WriteLine();
    }
}

class Truck : Vehicle
{
    public int PayloadCapacity;

    public Truck(int maxSpeed,string fuelType,int payloadCapacity) : base(maxSpeed, fuelType)
    {
        PayloadCapacity = payloadCapacity;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("Truck Details: ");
        base.DisplayDetails();
        Console.WriteLine("Payload Capacity: "+PayloadCapacity);
        Console.WriteLine();
    }
}

class MotorCycle : Vehicle
{
    public bool HasSidecar ;

    public MotorCycle(int maxSpeed,string fuelType,bool hasSidecar ) : base(maxSpeed, fuelType)
    {
        HasSidecar  = hasSidecar ;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("MotorCycle Details: ");
        base.DisplayDetails();
        Console.WriteLine("Has Sidecar: "+HasSidecar );
        Console.WriteLine();
    }
}
class VehicleAndTransportSystem
{
    static void Main(string[] args)
    {
        Vehicle[] vehicles = new Vehicle[3];

        vehicles[0] = new Car(180, "Petrol", 5);
        vehicles[1] = new Truck(120, "Diesel", 8000);
        vehicles[2] = new MotorCycle(150, "Petrol", false);

        for (int i = 0; i < vehicles.Length; i++)
        {
            vehicles[i].DisplayDetails(); // Polymorphism
        }
    }
}