using NUnit.Framework;
using System;

// ======================
// Calculator Class
// ======================
public class Calculator
{
    public int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new ArithmeticException("Division by zero is not allowed");
        }
        return a / b;
    }
}

// ======================
// NUnit Test Class
// ======================
[TestFixture]
public class CalculatorExceptionTests
{
    private Calculator calculator;

    [SetUp]
    public void Setup()
    {
        calculator = new Calculator();
    }

    [Test]
    public void Divide_ByZero_ThrowsArithmeticException()
    {
        Assert.That(
            () => calculator.Divide(10, 0),
            Throws.TypeOf<ArithmeticException>()
        );
    }
}
