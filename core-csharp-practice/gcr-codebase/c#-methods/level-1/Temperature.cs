using System;
class Temperature
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Temperature:");
         double temperature = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter WindSpeed:");
        double windSpeed = Convert.ToDouble(Console.ReadLine());

        double result = CalculateWindChill(temperature,windSpeed);
        Console.WriteLine("Chill Temperature:"+result);
    }
    public static double CalculateWindChill(double temperature, double windSpeed)
    {
        double windChill = 35.74 + 0.6215 *temperature + (0.4275*temperature - 35.75) * Math.Pow(windSpeed,0.16);

        return windChill;
    }
}