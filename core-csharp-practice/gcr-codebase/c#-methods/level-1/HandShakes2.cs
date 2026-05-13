using System;
class HandShakes2
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Number Of Students :");
        int numberOfStudents  = Convert.ToInt32(Console.ReadLine());

        int Handshakes = (numberOfStudents *(numberOfStudents -1))/2;

        Console.WriteLine("No. of Handshakes are :"+Handshakes);
    }
}