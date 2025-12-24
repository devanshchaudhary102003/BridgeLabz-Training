using System;
class BmiUsing2D
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of persons: ");
        int n = int.Parse(Console.ReadLine());

        double[][] personData = new double[n][];
        string[] weightStatus = new string[n];

        for (int i = 0; i < n; i++)
        {
            personData[i] = new double[3];
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Person:"+(i + 1));

            do
            {
                Console.Write("Enter height: ");
                personData[i][0] = double.Parse(Console.ReadLine());

                if (personData[i][0] <= 0)
                    Console.WriteLine("Height must be positive.");
            }
            while (personData[i][0] <= 0);

            do
            {
                Console.Write("Enter weight : ");
                personData[i][1] = double.Parse(Console.ReadLine());

                if (personData[i][1] <= 0)
                    Console.WriteLine("Weight must be positive.");
            }
            while (personData[i][1] <= 0);
        }

        for (int i = 0; i < n; i++)
        {
            double height = personData[i][0];
            double weight = personData[i][1];

            personData[i][2] = weight / (height * height);

            if (personData[i][2] < 18.5)
                weightStatus[i] = "Underweight";
            else if (personData[i][2] < 25)
                weightStatus[i] = "Normal";
            else if (personData[i][2] < 30)
                weightStatus[i] = "Overweight";
            else
                weightStatus[i] = "Obese";
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Height of "+(i+1)+" Person:"+personData[i][0]);
                Console.WriteLine("Weight of "+(i+1)+" Person:"+personData[i][1]);
                Console.WriteLine("Bmi of "+(i+1)+" Person:"+personData[i][2]);
                Console.WriteLine("Status of "+(i+1)+" Person:"+weightStatus[i]);
        }
    }
}