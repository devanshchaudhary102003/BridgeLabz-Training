using System;
class CalculateTheGrade
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] physics = new int[n];
        int[] chemistry = new int[n];
        int[] maths = new int[n];
        double[] percentage = new double[n];
        char[] grade = new char[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Student :"+(i + 1));

            Console.Write("Physics marks: ");
            physics[i] = Convert.ToInt32(Console.ReadLine());
            
            if (physics[i] < 0) { 
                i--; 
                continue; 
            }

            Console.Write("Chemistry marks: ");
            chemistry[i] = Convert.ToInt32(Console.ReadLine());
            
            if (chemistry[i] < 0) { 
                i--; 
                continue; 
                }

            Console.Write("Maths marks: ");
            maths[i] = Convert.ToInt32(Console.ReadLine());
            
            if (maths[i] < 0) { 
                i--; 
                continue; 
            }

            percentage[i] = (physics[i] + chemistry[i] + maths[i]) / 3.0;

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
            Console.WriteLine("Student:"+(i + 1)+": Physics="+(physics[i])+", Chemistry="+(chemistry[i])+", Maths="+(maths[i])+", Percentage="+percentage[i]+"%, Grade="+(grade[i]));
        }
    
    }
}