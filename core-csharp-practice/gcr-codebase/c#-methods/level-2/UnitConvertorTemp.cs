using System;
class UnitConvertorTemp
{
    public static double ConvertFahrenheitToCelsius(double fahrenheit)
    {
        double fahrenheit2celsius = (fahrenheit - 32) * 5 / 9;
        return fahrenheit2celsius;
    }

    public static double ConvertCelsiusToFahrenheit(double celsius)
    {
        double celsius2fahrenheit = (celsius * 9 / 5) + 32;
        return celsius2fahrenheit;
    }

    public static double ConvertPoundsToKilograms(double pounds)
    {
        double pounds2kilograms = 0.453592;
        return pounds * pounds2kilograms;
    }

    public static double ConvertKilogramsToPounds(double kilograms)
    {
        double kilograms2pounds = 2.20462;
        return kilograms * kilograms2pounds;
    }

    public static double ConvertGallonsToLiters(double gallons)
    {
        double gallons2liters = 3.78541;
        return gallons * gallons2liters;
    }

    public static double ConvertLitersToGallons(double liters)
    {
        double liters2gallons = 0.264172;
        return liters * liters2gallons;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("100 Fahrenheit to Celsius: " + UnitConvertorTemp.ConvertFahrenheitToCelsius(100));
        Console.WriteLine("37 Celsius to Fahrenheit: " + UnitConvertorTemp.ConvertCelsiusToFahrenheit(37));
        Console.WriteLine("150 Pounds to Kilograms: " + UnitConvertorTemp.ConvertPoundsToKilograms(150));
        Console.WriteLine("70 Kilograms to Pounds: " + UnitConvertorTemp.ConvertKilogramsToPounds(70));
        Console.WriteLine("5 Gallons to Liters: " + UnitConvertorTemp.ConvertGallonsToLiters(5));
        Console.WriteLine("10 Liters to Gallons: " + UnitConvertorTemp.ConvertLitersToGallons(10));
    }
}
