using System;

class Vehicle
{
    public int MaxSpeed;
    public string Model;

    public Vehicle(int maxSpeed, string model)
    {
        MaxSpeed = maxSpeed;
        Model = model;
    }

    public virtual void Operate()
    {
        Console.WriteLine("Vehicle is operating.");
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Model: " + Model);
        Console.WriteLine("Max Speed: " + MaxSpeed + " km/h");
    }
}

class ElectricVehicle : Vehicle
{
    public ElectricVehicle(int maxSpeed, string model)
        : base(maxSpeed, model) { }

    public override void Operate()
    {
        DisplayInfo();
        Console.WriteLine("Charging the electric vehicle.");
        Console.WriteLine();
    }
}

class PetrolVehicle : Vehicle
{
    public PetrolVehicle(int maxSpeed, string model)
        : base(maxSpeed, model) { }

    public override void Operate()
    {
        DisplayInfo();
        Console.WriteLine("Refueling the petrol vehicle.");
        Console.WriteLine();
    }
}

class VehicleManagementSystemwithHybridInheritance
{
    static void Main()
    {
        Vehicle v1 = new ElectricVehicle(160, "Tesla Model 3");
        Vehicle v2 = new PetrolVehicle(180, "Honda City");

        v1.Operate();
        v2.Operate();
    }
}
