using System;
using System.Reflection;

class MathOperations
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }
}

class DynamicMethodInvocation
{
    static void Main(string[] args)
    {
        Console.Write("Enter method name (Add / Subtract / Multiply): ");
        string methodName = Console.ReadLine();

        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());

        // Reflection logic
        Type type = typeof(MathOperations);
        object obj = Activator.CreateInstance(type);

        MethodInfo method = type.GetMethod(methodName);

        if (method != null)
        {
            object result = method.Invoke(obj, new object[] { a, b });
            Console.WriteLine("Result: " + result);
        }
        else
        {
            Console.WriteLine("Invalid method name!");
        }
    }
}
