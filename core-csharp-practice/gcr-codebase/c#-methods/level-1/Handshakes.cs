using System;
class Handshakes
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of People:");
        int number = Convert.ToInt32(Console.ReadLine());

        int Handshakes = CalculateHandshake(number);

        Console.WriteLine("No. of Handshakes are :"+Handshakes);
    }
    static int CalculateHandshake(int number)
    {
        return (number*(number-1))/2;
    }
}