using System;

class NestedTryCatch
{
    static void Main()
    {
        int[] arr = { 10, 20, 30, 40, 50 };

        Console.Write("Enter index: ");
        int index = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter divisor: ");
        int divisor = Convert.ToInt32(Console.ReadLine());

        try
        {
            // Outer try: handles array index issues
            int value = arr[index];

            try
            {
                // Inner try: handles division issues
                int result = value / divisor;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero!");
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid array index!");
        }
    }
}
