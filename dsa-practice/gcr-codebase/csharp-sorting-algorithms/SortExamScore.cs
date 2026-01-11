using System;
class SortExamScore
{
    public static void SelectionSort(int[] Exam)
    {
        int n = Exam.Length;

        for(int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for(int j = i+1; j < n; j++)
            {
                if(Exam[j] < Exam[minIndex])
                {
                    minIndex = j;
                }
            }
            //swap
            int temp = Exam[minIndex];
            Exam[minIndex] = Exam[i];
            Exam[i] = temp;
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter The Length: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] Exam = new int[n];
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Exam Score: ");
            Exam[i] = Convert.ToInt32(Console.ReadLine());
        }

        SelectionSort(Exam);

        Console.WriteLine("Sorted Exam Score: ");
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine(Exam[i]+" ");
        }
    }
}