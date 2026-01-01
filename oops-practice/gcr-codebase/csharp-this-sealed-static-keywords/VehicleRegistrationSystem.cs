using System;
class Vehicle
{
    public static int RegistrationFee = 5000;
    public string OwnerName;
    public string VehicleType;
    public readonly int RegistrationNumber;

    public Vehicle(string OwnerName,string VehicleType,int RegistrationNumber)
    {
        this.OwnerName = OwnerName;
        this.VehicleType = VehicleType;
        this.RegistrationNumber = RegistrationNumber;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Registration Fee:"+RegistrationFee);
        Console.WriteLine("Owner Name:"+OwnerName);
        Console.WriteLine("Vehicle Type:"+VehicleType);
        Console.WriteLine("Registration Number:"+RegistrationNumber);
    }
    public static void UpdateRegistrationFee(int NewRegistrationFee)
    {
        RegistrationFee = NewRegistrationFee;
        Console.WriteLine("Update Registration Fee:"+RegistrationFee);
    }
}
class VehicleRegistrationSystem
{
    static void Main(string[] args)
    {
        Vehicle v1 = new Vehicle("Devansh","Bike",2215);
        Vehicle v2 = new Vehicle("Rohit","Car",5588);

        if(v1 is Vehicle)
        {
            Console.WriteLine("v1 is a Vehicle Object");
            v1.DisplayDetails();
        }

        Console.WriteLine();

        if(v2 is Vehicle)
        {
            Console.WriteLine("v2 is a Vehicle Object");
            v2.DisplayDetails();
        }

        Console.WriteLine();

        Vehicle.UpdateRegistrationFee(6500);

        Console.WriteLine();
        v1.DisplayDetails();
        Console.WriteLine();
        v2.DisplayDetails();
    }
}