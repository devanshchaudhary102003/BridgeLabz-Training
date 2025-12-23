using System;
using System.Collections;
using System.Diagnostics;
class Calculator
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter First Number:");
        int FirstNumber = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Second Number:");
        int SecondNumber = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Operator:");
        String Operator = Console.ReadLine();

        switch(Operator){
            case "+":
                Console.WriteLine(FirstNumber+SecondNumber);
                break;
            case "-":
                Console.WriteLine(FirstNumber-SecondNumber);
                break;
            case "*":
                Console.WriteLine(FirstNumber*SecondNumber);
                break;
            case "/":
                Console.WriteLine(FirstNumber/SecondNumber);
                break;
            default:
                Console.WriteLine("Invalid Operator");
                break;
        }
    }
}