using System;
class SortStudentMarks
{
    public static void swap(int[] studentMarks)
    {
        int n = studentMarks.Length;

        for(int i = 0; i < n - 1; i++)
        {
            for(int j = 0; j < n - i - 1; j++)
            {
                if(studentMarks[j] > studentMarks[j + 1])
                {
                    int temp = studentMarks[j];
                    studentMarks[j] = studentMarks[j+1];
                    studentMarks[j+1] = temp;
                }
            }
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter The Length: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] studentMarks = new int[n];
        for(int i = 0; i < n; i++)
        {
            studentMarks[i] = Convert.ToInt32(Console.ReadLine());
        }

        swap(studentMarks);
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Sorted Student Marks: "+studentMarks[i]+" ");
        }
    }
}