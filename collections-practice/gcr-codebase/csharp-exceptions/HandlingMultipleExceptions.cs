using System;

class HandlingMultipleException
{
    static void Main(string[] args)
    {
        try
        {
            // Uncomment ONE to test

            // int[] arr = null;                 // Case 1: Null array
            int[] arr = { 10, 20, 30, 40, 50 };  // Case 2: Valid array

            Console.Write("Enter index: ");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Value at index " + index + ": " + arr[index]);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid index!");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Array is not initialized!");
        }
    }
}
