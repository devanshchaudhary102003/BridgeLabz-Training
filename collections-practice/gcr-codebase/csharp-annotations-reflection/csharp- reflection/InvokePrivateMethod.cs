using System;
using System.Reflection;

class Calculator
{
    // Private method
    private int Multiply(int a, int b)
    {
        return a * b;
    }
}

class InvokePrivateMethod
{
    static void Main(string[] args)
    {
        // Create Calculator object
        Calculator calc = new Calculator();

        // Get type of Calculator
        Type type = typeof(Calculator);

        // Get private method using Reflection
        MethodInfo method = type.GetMethod(
            "Multiply",
            BindingFlags.NonPublic | BindingFlags.Instance
        );

        // Invoke private method
        object result = method.Invoke(calc, new object[] { 4, 5 });

        // Display result
        Console.WriteLine("Result: " + result);
    }
}
