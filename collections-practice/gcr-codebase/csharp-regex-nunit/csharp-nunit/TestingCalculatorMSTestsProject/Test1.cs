using Microsoft.VisualStudio.TestTools.UnitTesting;
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
// Test Class (MSTest)
// ======================
[TestClass]
public class CalculatorTests
{
    private Calculator calculator = null!;

    [TestInitialize]
    public void Setup()
    {
        calculator = new Calculator();
    }

    [TestMethod]
    public void Add_Test()
    {
        Assert.AreEqual(15, calculator.Add(10, 5));
    }

    [TestMethod]
    public void Subtract_Test()
    {
        Assert.AreEqual(5, calculator.Subtract(10, 5));
    }

    [TestMethod]
    public void Multiply_Test()
    {
        Assert.AreEqual(20, calculator.Multiply(4, 5));
    }

    [TestMethod]
    public void Divide_Test()
    {
        Assert.AreEqual(5, calculator.Divide(10, 2));
    }

    [TestMethod]
    public void Divide_ByZero_ShouldThrow()
    {
        try
        {
            calculator.Divide(10, 0);
            Assert.Fail("Expected DivideByZeroException but no exception was thrown.");
        }
        catch (DivideByZeroException)
        {
            Assert.IsTrue(true);
        }
    }
}
