using System;
class Bmi
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Weight(kg):");
        double weight = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter Height(cm):");
        double Height = Convert.ToDouble(Console.ReadLine());

        double Hecm = Height/100;

        double Bmi = (weight)/(Hecm*Hecm);
        Console.WriteLine(Bmi);

        if(Bmi <= 18.4)
        {
            Console.WriteLine("Underweight");
        }
        else if(Bmi >= 18.4 && Bmi <= 24.9)
        {
            Console.WriteLine("Normal");
        }
        else if(Bmi >= 25 && Bmi <= 39.9)
        {
            Console.WriteLine("Overweight");
        }
        else
        {
            Console.WriteLine("Obese");
        }
    }
}