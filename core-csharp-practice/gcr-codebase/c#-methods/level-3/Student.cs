using System;

class Student
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] marks = GenerateRandomScores(n);

        double[,] results = CalculateResults(marks, n);

        DisplayScorecard(marks, results, n);
    }

    public static int[,] GenerateRandomScores(int n)
    {
        int[,] scores = new int[n, 3];
        Random rand = new Random();

        for (int i = 0; i < n; i++)
        {
            scores[i, 0] = rand.Next(10, 100); 
            scores[i, 1] = rand.Next(10, 100); 
            scores[i, 2] = rand.Next(10, 100); 
        }

        return scores;
    }

    public static double[,] CalculateResults(int[,] marks, int n)
    {
        double[,] results = new double[n, 3]; 

        for (int i = 0; i < n; i++)
        {
            double total = marks[i, 0] + marks[i, 1] + marks[i, 2];
            double average = total / 3.0;
            double percentage = (total / 300.0) * 100; 

            results[i, 0] = Math.Round(total, 2);
            results[i, 1] = Math.Round(average, 2);
            results[i, 2] = Math.Round(percentage, 2);
        }

        return results;
    }

    public static void DisplayScorecard(int[,] marks, double[,] results, int n)
    {
        Console.WriteLine("Student Physics Chemistry Maths Total Average Percentage");
        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} {1} {2}  {3} {4} {5} {6}",i + 1,marks[i, 0],marks[i, 1],marks[i, 2],results[i, 0],results[i, 1],results[i, 2]);
        }
    }
}
