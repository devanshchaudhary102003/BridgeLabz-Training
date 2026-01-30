using System;
using System.Collections.Generic;

public class InvalidFlightException : Exception
{
    public InvalidFlightException(string message) : base(message)
    {
    }
}

public class FlightUtil
{
    private static readonly Dictionary<string, int> MaxPassengerCapacity =
        new Dictionary<string, int>(StringComparer.Ordinal)
        {
            { "SpiceJet", 396 },
            { "Vistara", 615 },
            { "IndiGo", 230 },
            { "Air Arabia", 130 }
        };

    private static readonly Dictionary<string, double> FuelTankCapacity =
        new Dictionary<string, double>(StringComparer.Ordinal)
        {
            { "SpiceJet", 200000.0 },
            { "Vistara", 300000.0 },
            { "IndiGo", 250000.0 },
            { "Air Arabia", 150000.0 }
        };

    public bool validateFlightNumber(string flightNumber)
    {
        // Pattern: FL-XXXX where XXXX is 1000..9999
        if (string.IsNullOrWhiteSpace(flightNumber))
            throw new InvalidFlightException("The flight number " + flightNumber + " is invalid");

        if (flightNumber.Length != 7) // "FL-" (3) + 4 digits
            throw new InvalidFlightException("The flight number " + flightNumber + " is invalid");

        if (!flightNumber.StartsWith("FL-"))
            throw new InvalidFlightException("The flight number " + flightNumber + " is invalid");

        string digits = flightNumber.Substring(3, 4);
        int num;
        if (!int.TryParse(digits, out num))
            throw new InvalidFlightException("The flight number " + flightNumber + " is invalid");

        if (num < 1000 || num > 9999)
            throw new InvalidFlightException("The flight number " + flightNumber + " is invalid");

        return true;
    }

    public bool validateFlightName(string flightName)
    {
        // Case-insensitive match against allowed names
        if (string.IsNullOrWhiteSpace(flightName))
            throw new InvalidFlightException("The flight name " + flightName + " is invalid");

        bool ok =
            flightName.Equals("SpiceJet", StringComparison.OrdinalIgnoreCase) ||
            flightName.Equals("Vistara", StringComparison.OrdinalIgnoreCase) ||
            flightName.Equals("IndiGo", StringComparison.OrdinalIgnoreCase) ||
            flightName.Equals("Air Arabia", StringComparison.OrdinalIgnoreCase);

        if (!ok)
            throw new InvalidFlightException("The flight name " + flightName + " is invalid");

        return true;
    }

    public bool validatePassengerCount(int passengerCount, string flightName)
    {
        // Note in problem statement also says flightName is case-sensitive (so use exact key)
        // We will assume flightName is provided in correct case as per sample.
        if (!MaxPassengerCapacity.ContainsKey(flightName))
        {
            // If somehow called without a valid name, treat as invalid by spec-style
            throw new InvalidFlightException("The flight name " + flightName + " is invalid");
        }

        int max = MaxPassengerCapacity[flightName];

        if (passengerCount <= 0 || passengerCount > max)
            throw new InvalidFlightException("The passenger count " + passengerCount + " is invalid for " + flightName);

        return true;
    }

    public double calculateFuelToFillTank(string flightName, double currentFuelLevel)
    {
        if (!FuelTankCapacity.ContainsKey(flightName))
        {
            // Not expected if validateFlightName passed, but keep safe.
            throw new InvalidFlightException("Invalid fuel level for " + flightName);
        }

        double capacity = FuelTankCapacity[flightName];

        if (currentFuelLevel < 0 || currentFuelLevel > capacity)
            throw new InvalidFlightException("Invalid fuel level for " + flightName);

        return capacity - currentFuelLevel;
    }
}

public class AeroVigil
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter flight details");

        try
        {
            string input = Console.ReadLine();

            // Expect: FlightNumber:FlightName:PassengerCount:CurrentFuelLevel
            string[] parts = input.Split(':');
            if (parts.Length != 4)
            {
                // Not specified, but prevents crash for bad input format.
                Console.WriteLine("Invalid input format");
                return;
            }

            string flightNumber = parts[0];
            string flightName = parts[1]; // keep as-is (case-sensitive note)
            int passengerCount;
            double currentFuelLevel;

            if (!int.TryParse(parts[2], out passengerCount) ||
                !double.TryParse(parts[3], out currentFuelLevel))
            {
                Console.WriteLine("Invalid input format");
                return;
            }

            FlightUtil util = new FlightUtil();

            util.validateFlightNumber(flightNumber);
            util.validateFlightName(flightName);
            util.validatePassengerCount(passengerCount, flightName);

            double fuelNeeded = util.calculateFuelToFillTank(flightName, currentFuelLevel);

            Console.WriteLine("Fuel required to fill the tank: " + fuelNeeded + " liters");
        }
        catch (InvalidFlightException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception)
        {
            // Generic safety net to prevent crashes for unexpected inputs
            Console.WriteLine("Invalid input format");
        }
    }
}
