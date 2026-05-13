using System;
class Freelencers
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Invoice Details:");
        string input = Console.ReadLine();

        string[] tasks = ParseInvoice(input);
        int totalAmount = GetTotalAmount(tasks);

        Console.WriteLine("--------- Invoice tasks ----------");
        for(int i = 0; i < tasks.Length; i++)
        {
            Console.WriteLine(tasks[i]);
        }
        Console.WriteLine("Total Invoice Amount: " + totalAmount + " INR");
    }

    //Method to split invoice string into tasks
    static string[] ParseInvoice(string input)
    {
        //Split by cooms to get individual tasks
        string[] tasks = input.Split(',');

        for(int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = tasks[i].Trim();
        }
        return tasks;
    }

    static int GetTotalAmount(string[] tasks)
    {
        int total = 0;

        for(int i = 0; i < tasks.Length; i++)
        {
            //Example: "Logo Design - 3000 INR"
            string[] parts = tasks[i].Split('-');

            // parts[1] = " 3000 INR"
            string amountPart = parts[1].Trim();

            // Split to remove INR
            string[] amountWords = amountPart.Split(' ');

            int amount = Convert.ToInt32(amountWords[0]);
            total += amount;
        }
        return total;
    }

}