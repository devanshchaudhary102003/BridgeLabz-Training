using NUnit.Framework;

// ======================
// TemperatureConverter Class
// ======================
public class TemperatureConverter
{
    public double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    public double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }
}

// ======================
// NUnit Test Class
// ======================
[TestFixture]
public class TemperatureConverterTests
{
    private TemperatureConverter converter;

    [SetUp]
    public void SetUp()
    {
        converter = new TemperatureConverter();
    }

    // Celsius → Fahrenheit Tests
    [Test]
    public void CelsiusToFahrenheit_ZeroCelsius_Returns32F()
    {
        double result = converter.CelsiusToFahrenheit(0);
        Assert.That(result, Is.EqualTo(32).Within(0.01));
    }

    [Test]
    public void CelsiusToFahrenheit_100Celsius_Returns212F()
    {
        double result = converter.CelsiusToFahrenheit(100);
        Assert.That(result, Is.EqualTo(212).Within(0.01));
    }

    //  Fahrenheit → Celsius Tests
    [Test]
    public void FahrenheitToCelsius_32Fahrenheit_Returns0C()
    {
        double result = converter.FahrenheitToCelsius(32);
        Assert.That(result, Is.EqualTo(0).Within(0.01));
    }

    [Test]
    public void FahrenheitToCelsius_212Fahrenheit_Returns100C()
    {
        double result = converter.FahrenheitToCelsius(212);
        Assert.That(result, Is.EqualTo(100).Within(0.01));
    }
}
