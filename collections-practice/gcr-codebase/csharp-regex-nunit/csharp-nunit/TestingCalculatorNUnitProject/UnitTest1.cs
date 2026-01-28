using NUnit.Framework;
using System;

// ======================
// Calculator Class
// ======================
public class Calculator
{
    public int Add(int a, int b) { return a + b; }
    public int Subtract(int a, int b) { return a - b; }
    public int Multiply(int a, int b) { return a * b; }

    public int Divide(int a, int b)
    {
        if (b == 0) throw new DivideByZeroException("Cannot divide by zero");
        return a / b;
    }
}

// ======================
// NUnit Tests
// ======================
[TestFixture]
public class CalculatorTests
{
    private Calculator calculator;

    [SetUp]
    public void Setup()
    {
        calculator = new Calculator();
    }

    [Test]
    public void Add_Test()
    {
        int result = calculator.Add(10, 5);
        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void Subtract_Test()
    {
        int result = calculator.Subtract(10, 5);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Multiply_Test()
    {
        int result = calculator.Multiply(4, 5);
        Assert.That(result, Is.EqualTo(20));
    }

    [Test]
    public void Divide_Test()
    {
        int result = calculator.Divide(10, 2);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Divide_ByZero_ShouldThrow()
    {
        Assert.That(() => calculator.Divide(10, 0), Throws.TypeOf<DivideByZeroException>());
    }
}
