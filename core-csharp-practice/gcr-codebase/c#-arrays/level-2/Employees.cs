using System;
class Employees
{
    static void Main(string[] args)
    {
        double[] OldSalary = new double[10];
        double[] Year = new double[10];
        double[] Bonus = new double[10];
        double[] NewSalary = new double[10];

        double TotalBonus = 0;
        double TotalOldSalary = 0;
        double TotalNewSalary = 0;


        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine("Enter the salary of "+(i+1)+"th Employee:");
            OldSalary[i] = Convert.ToDouble(Console.ReadLine());
        }

        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine("Enter the Year of "+(i+1)+"th Employee");
            Year[i] = Convert.ToDouble(Console.ReadLine());
        }

        for(int i = 0; i < 10; i++)
        {
            if(Year[i] > 5)
            {
                Bonus[i] = OldSalary[i] * 0.05;
            }
            else{
                Bonus[i] = OldSalary[i] * 0.02;
            }

            NewSalary[i] = OldSalary[i] + Bonus[i];

            TotalBonus += Bonus[i];
            TotalOldSalary += OldSalary[i];
            TotalNewSalary += NewSalary[i];

            Console.WriteLine("Total Old Salary of "+(i+1)+" Employee :"+TotalOldSalary);
            Console.WriteLine("Total Total Bonus of "+(i+1)+" Employee :"+TotalBonus);
            Console.WriteLine("Total  New Salary of "+(i+1)+" Employee :"+TotalNewSalary);
        }
    }
}