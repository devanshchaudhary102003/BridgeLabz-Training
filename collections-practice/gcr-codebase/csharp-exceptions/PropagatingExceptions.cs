using System;

class PropagatingExceptions
{
    static void Method1()
    {
        int a = 10;
        int b = 0;
        int result = a / b;   // ArithmeticException here
    }

    static void Method2()
    {
        Method1();   // Exception propagates from Method1 to Method2
    }

    static void Main(string[] args)
    {
        try
        {
            Method2();   // Exception propagates from Method2 to Main
        }
        catch (ArithmeticException)
        {
            Console.WriteLine("Handled exception in Main");
        }
    }
}
