using System;

class Bmi
{
    static void Main(string[] args)
    {
        int numberOfPersons = 10;

        double[,] personData = new double[numberOfPersons, 3];
        string[] bmiStatus = new string[numberOfPersons];

        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.WriteLine("Enter details for Person " + (i + 1));

            Console.Write("Enter weight: ");
            personData[i, 0] = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter height: ");
            personData[i, 1] = Convert.ToDouble(Console.ReadLine());
        }

        CalculateBMI(personData);

        bmiStatus = GetBMIStatus(personData);

        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.WriteLine("Person " + (i + 1) +" | Weight: " + personData[i, 0] + " kg" +" | Height: " + personData[i, 1] + " cm" +" | BMI: " + personData[i, 2] +" | Status: " + bmiStatus[i]);
        }
    }

    public static void CalculateBMI(double[,] data)
    {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            double heightInMeters = data[i, 1] / 100; // cm to meter
            data[i, 2] = data[i, 0] / (heightInMeters * heightInMeters);
        }
    }

    public static string[] GetBMIStatus(double[,] data)
    {
        int size = data.GetLength(0);
        string[] status = new string[size];

        for (int i = 0; i < size; i++)
        {
            double bmi = data[i, 2];

            if(bmi < 18.5)
            {
                status[i] = "Underweight";
            }
            else if(bmi >= 18.5 && bmi < 25)
            {
                status[i] = "Normal weight";
            }
            else if(bmi >= 25 && bmi < 30)
            {
                status[i] = "Overweight";
            }
            else
            {
                status[i] = "Obese";
            }
        }

        return status;
    }
}
