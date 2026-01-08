using System;
interface IControllable
{
    void TurnOn();
    void TurnOff();
    bool GetStatus();
}
abstract class Appliance
{
    private string ApplianceName;
    protected bool IsOn;

    public string applianceName
    {
        get
        {
            return ApplianceName;
        }
        set
        {
            ApplianceName = value;
        }
    }

    public Appliance()
    {
        IsOn = false;   //starting status OFF
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Appliance Name: "+ApplianceName);
        Console.WriteLine("Current Status: "+(IsOn ? "ON" : "OFF"));
    }
}

class Light : Appliance,IControllable
{
    public void TurnOn()
    {
        IsOn = true;
        Console.WriteLine("Light is ON");
    }

    public void TurnOff()
    {
        IsOn = false;
        Console.WriteLine("Light is OFF");
    }

    public bool GetStatus()
    {
        return IsOn;
    }
}

class Fan : Appliance,IControllable
{
    public void TurnOn()
    {
        IsOn = true;
        Console.WriteLine("Fan is ON");
    }

    public void TurnOff()
    {
        IsOn = false;
        Console.WriteLine("Fan is OFF");
    }
    public bool GetStatus()
    {
        return IsOn;
    }
}

class AC : Appliance,IControllable
{
    public void TurnOn()
    {
        IsOn = true;
        Console.WriteLine("AC is ON");
    }

    public void TurnOff()
    {
        IsOn = false;
        Console.WriteLine("AC is OFF");
    }
    public bool GetStatus()
    {
        return IsOn;
    }
}
class SmartHomeAutomationSystem
{
    static void Main(string[] args)
    {
        Appliance[] appliance = new Appliance[3];

        appliance[0] = new Light();
        appliance[0].applianceName = "Light";

        appliance[1] = new Fan();
        appliance[1].applianceName = "Fan";

        appliance[2] = new AC();
        appliance[2].applianceName = "AC";

        Console.WriteLine("Starting Status of Appliances.......");
        for(int i = 0; i < appliance.Length; i++)
        {
            appliance[i].DisplayDetails();
            Console.WriteLine();
        }

        while (true)
        {
            Console.WriteLine("\n-------- Smart Home Menu -------------");
            Console.WriteLine("1. Light");
            Console.WriteLine("2. Fan");
            Console.WriteLine("3. AC");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Select Appliance: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            if(choice == 4)
            {
                break;
            }

            Console.WriteLine("1. Turn ON");
            Console.WriteLine("2. Turn OFF");
            Console.WriteLine("Select Action: ");

            int action = Convert.ToInt32(Console.ReadLine());

            if(choice >=1 && choice <=3)
            {
                    Appliance selectedAppliance = appliance[choice -1];
                    IControllable control = (IControllable)selectedAppliance;

                    selectedAppliance.DisplayDetails();

                    switch (action)
                    {
                        case 1:
                            control.TurnOn();
                            break;
                        
                        case 2:
                            control.TurnOff();
                            break;

                        default:
                            Console.WriteLine("Invalid Action");
                            break;
                    }
            
            }
            else
            {
                Console.WriteLine("Invalid Appliance Choice");
            }
        }
        
        Console.WriteLine("Ending Status of Appliances.......");
        for(int i = 0; i < appliance.Length; i++)
        {
            appliance[i].DisplayDetails();
            Console.WriteLine();
        }

        Console.WriteLine("Smart Home System Closed.....");
    }
}