using System;
class Vote
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Age: ");
        int Age = Convert.ToInt32(Console.ReadLine());


        if(Age >= 18){
            Console.WriteLine("The person's age is "+Age+" and can vote.");
        }
        else
        {
            Console.WriteLine("The person's age is "+Age+" and cannot vote.");
        }
    }
}