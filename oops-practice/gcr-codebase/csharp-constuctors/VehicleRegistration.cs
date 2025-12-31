using System;
public class Vehicle
{
    public string OwnerName;
    public string VehicleType;

    static int RegistrationFee;

    public Vehicle(string ownerName,string vehicleType)
    {
        OwnerName = ownerName;
        VehicleType = vehicleType;
    }

    public void DisplayVehicleDetails()
    {
        Console.WriteLine("Owner Name:"+OwnerName);
        Console.WriteLine("Vehicle Type:"+VehicleType);
    }

    public static void UpdateRegistrationFee(int newFee)
    {
        RegistrationFee = newFee;
        Console.WriteLine("Registration Fee:"+RegistrationFee);

    }
}
class VehicleRegistration
{
    static void Main(string[] args)
    {
        Vehicle v1 = new Vehicle("Devansh Singh","Two Wheeler");
        v1.DisplayVehicleDetails();
        Vehicle.UpdateRegistrationFee(5000);

        Vehicle v2 = new Vehicle("Dev Chaudhary","Four Wheeler");
        v2.DisplayVehicleDetails();
        Vehicle.UpdateRegistrationFee(10000);
    }
}