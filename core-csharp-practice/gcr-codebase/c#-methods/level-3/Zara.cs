using System;

class Zara
{
    static void Main(string[] args)
    {
        const int totalEmployees = 10;

        double[,] employees = GenerateSalaryAndService(totalEmployees);

        Console.WriteLine("Employee Old Salary Years of Service");
        for (int i = 0; i < totalEmployees; i++)
        {
            Console.WriteLine("{0}  {1:F2}  {2}", i + 1, employees[i, 0], (int)employees[i, 1]);
        }

        double[,] newEmployees = CalculateNewSalaryAndBonus(employees, totalEmployees);

        Console.WriteLine("Employee Old Salary Bonus New Salary");
        for (int i = 0; i < totalEmployees; i++)
        {
            Console.WriteLine("{0} {1:F2} {2:F2}{3:F2}", i + 1, employees[i, 0], newEmployees[i, 1], newEmployees[i, 0]);
        }

        CalculateTotals(employees, newEmployees, totalEmployees);
    }

    public static double[,] GenerateSalaryAndService(int totalEmployees)
    {
        double[,] empData = new double[totalEmployees, 2];
        Random rand = new Random();

        for (int i = 0; i < totalEmployees; i++)
        {
            empData[i, 0] = rand.Next(10000, 99999); 
            empData[i, 1] = rand.Next(1, 11);        
        }

        return empData;
    }

    public static double[,] CalculateNewSalaryAndBonus(double[,] empData, int totalEmployees)
    {
        double[,] newData = new double[totalEmployees, 2]; 

        for (int i = 0; i < totalEmployees; i++)
        {
            double oldSalary = empData[i, 0];
            int years = (int)empData[i, 1];

            double bonusPercentage = (years > 5) ? 0.05 : 0.02;
            double bonus = oldSalary * bonusPercentage;
            double newSalary = oldSalary + bonus;

            newData[i, 0] = newSalary;
            newData[i, 1] = bonus;
        }

        return newData;
    }

    public static void CalculateTotals(double[,] oldData, double[,] newData, int totalEmployees)
    {
        double sumOld = 0, sumNew = 0, totalBonus = 0;

        for (int i = 0; i < totalEmployees; i++)
        {
            sumOld += oldData[i, 0];
            sumNew += newData[i, 0];
            totalBonus += newData[i, 1];
        }

        Console.WriteLine("Total Old Salary: {0:F2}", sumOld);
        Console.WriteLine("Total Bonus: {0:F2}", totalBonus);
        Console.WriteLine("Total New Salary: {0:F2}", sumNew);
    }
}
