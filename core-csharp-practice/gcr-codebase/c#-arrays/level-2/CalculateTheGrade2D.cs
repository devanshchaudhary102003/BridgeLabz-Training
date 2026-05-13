using System;
class CalculateTheGrade2D
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] marks = new int[n, 3]; 
        double[] percentage = new double[n];
        char[] grade = new char[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Student :"+(i + 1));

            for (int j = 0; j < 3; j++)
            {
                string subject = j == 0 ? "Physics" : j == 1 ? "Chemistry" : "Maths";
                Console.Write(subject+"marks: ");
                marks[i, j] = Convert.ToInt32(Console.ReadLine());

                if (marks[i, j] < 0)
                {
                    Console.WriteLine("Marks must be positive.");
                    i--;
                    break;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            int total = marks[i, 0] + marks[i, 1] + marks[i, 2];
            percentage[i] = total / 3.0;

            if (percentage[i] >= 80)
            {
                grade[i] = 'A';
            }
            else if (percentage[i] >= 70) 
            {
                grade[i] = 'B';
            }
            else if (percentage[i] >= 60) 
            {
                grade[i] = 'C';
            }
            else if (percentage[i] >= 50) 
            {
                grade[i] = 'D';
            }
            else if (percentage[i] >= 40) 
            {
                grade[i] = 'E';
            }
            else 
            {
                grade[i] = 'R';
            }
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Student:"+(i + 1)+": Physics="+(marks[i,0])+", Chemistry="+(marks[i,1])+", Maths="+(marks[i,2])+", Percentage="+percentage[i]+"%, Grade="+(grade[i]));
        }
    }
}