using System;
    class StudentScore
{
    static void Main(string[] args)
    {
        StudentScore student = new StudentScore();

        int[] scores = student.UserInput();
        int avg = student.AverageMarks(scores);

        student.HighestMarks(scores);
        student.LowestMarks(scores);
        student.DisplayAboveTheAverage(scores,avg);
    }
    //Input no. of students
    public int[] UserInput()
    {
        Console.WriteLine("Enter the no. of student:");
        int NumberOfStudent = Convert.ToInt16(Console.ReadLine());

        int[] arr = new int[NumberOfStudent];
        Random r = new Random();

        for(int i = 0; i < NumberOfStudent; i++)
        {
            arr[i] = r.Next(0,101);
        }
        return arr;
    }

    public int AverageMarks(int[] marks)
    {
        int sum = 0;

        for(int i = 0; i < marks.Length; i++)
        {
            sum = sum + marks[i];
        }
        int average = sum / marks.Length;

        Console.WriteLine("Average Marks of Students are:"+average);

        return average;
    }

    public void HighestMarks(int[] marks)
    {
        int Highest = marks[0];

        for(int i = 1; i < marks.Length; i++)
        {
            if(marks[i] > Highest)
            {
                Highest = marks[i];
            }
        }
        Console.WriteLine("Highest marks of the student:"+Highest);
    }

    public void LowestMarks(int[] marks)
    {
        int Lowest = marks[0];

        for(int i = 1; i < marks.Length; i++)
        {
            if(marks[i] < Lowest)
            {
                Lowest = marks[i];
            }
        }
        Console.WriteLine("Lowest marks of the student:"+Lowest);
    }

    public void DisplayAboveTheAverage(int[] marks,int average)
    {
        Console.WriteLine("Scores above the Average:");
        for(int i = 0; i < marks.Length; i++)
        {
            if(marks[i] > average)
            {
                Console.WriteLine("Scores above the Average:"+marks[i]);
            }
        }
    }
}
