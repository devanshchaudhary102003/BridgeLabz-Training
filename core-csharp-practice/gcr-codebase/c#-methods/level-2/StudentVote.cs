using System;

public class StudentVote
{    
    static void Main(string[] args)
    {
        int[] ages = new int[10];
        for (int i = 0; i < ages.Length; i++)
        {
            Console.Write("Enter age of student " + (i + 1) + ": ");
            ages[i] = Convert.ToInt32(Console.ReadLine());

            bool Vote = CalculateStudentVote(ages[i]);

            if (Vote)
            {
                Console.WriteLine("Student " + (i + 1) + " can vote");
            }
            else
            {
                Console.WriteLine("Student " + (i + 1) + " cannot vote");
            }
        }
    }
    public static bool CalculateStudentVote(int age)
    {
        if (age < 0)
        {
            return false;
        }

        if (age >= 18)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
