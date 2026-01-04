using System;

class Device
{
    public int DeviceId;
    public string Status;

    public Device(int deviceId, string status)
    {
        DeviceId = deviceId;
        Status = status;
    }

    public virtual void DisplayStatus()
    {
        Console.WriteLine("Device ID: " + DeviceId);
        Console.WriteLine("Status: " + Status);
    }
}

class Thermostat : Device
{
    public int TemperatureSetting;

    public Thermostat(int deviceId, string status, int temperature)
        : base(deviceId, status)
    {
        TemperatureSetting = temperature;
    }

    public override void DisplayStatus()
    {
        base.DisplayStatus();
        Console.WriteLine("Temperature Setting: " + TemperatureSetting + "°C");
    }
}

class SmartHomeDevices
{
    static void Main()
    {
        Thermostat t1 = new Thermostat(101, "ON", 24);
        t1.DisplayStatus();
    }
}
