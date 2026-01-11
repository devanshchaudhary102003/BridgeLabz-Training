using System;
class SortJobApplicantsBySalary
{
    static void Heapify(int[] salary, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && salary[left] > salary[largest])
            largest = left;

        if (right < n && salary[right] > salary[largest])
            largest = right;

        if (largest != i)
        {
            int temp = salary[i];
            salary[i] = salary[largest];
            salary[largest] = temp;

            Heapify(salary, n, largest);
        }
    }

    static void HeapSort(int[] salary)
    {
        int n = salary.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(salary, n, i);
        }

        for (int i = n - 1; i > 0; i--)
        {
           
            int temp = salary[0];
            salary[0] = salary[i];
            salary[i] = temp;

            Heapify(salary, i, 0);
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Enter number of job applicants: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] salary = new int[n];

        Console.WriteLine("Enter expected salaries:");
        for (int i = 0; i < n; i++)
        {
            salary[i] = Convert.ToInt32(Console.ReadLine());
        }

        HeapSort(salary);

        Console.WriteLine("\nSalaries sorted in ascending order:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(salary[i] + " ");
        }
    }

}