using System;
class BonusOfEmployees
{
    static void Main(string[] args)
    {
        Console.WriteLine("Year of Service: ");
        int Service = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Take Salary: ");
        int Salary = Convert.ToInt32(Console.ReadLine());

        if(Service >= 5)
        {
            int Bonus = (5*Salary)/100;
            Console.WriteLine("Bonus Amount:"+Bonus);
        }
        else
        {
            Console.WriteLine("No Bonus");
        }
    }
}
