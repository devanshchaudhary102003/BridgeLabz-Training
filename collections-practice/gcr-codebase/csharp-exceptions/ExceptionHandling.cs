using System;

// 1️⃣ Custom Exception
class InvalidAgeException : Exception
{
    public InvalidAgeException(string message) : base(message)
    {
    }
}

class ExceptionHandling
{
    // 2️⃣ Method to validate age
    static void ValidateAge(int age)
    {
        if (age < 18)
        {
            throw new InvalidAgeException("Age must be 18 or above");
        }

        Console.WriteLine("Access granted!");
    }

    // 3️⃣ Main method
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            ValidateAge(age);
        }
        catch (InvalidAgeException)
        {
            Console.WriteLine("Age must be 18 or above");
        }
    }
}
