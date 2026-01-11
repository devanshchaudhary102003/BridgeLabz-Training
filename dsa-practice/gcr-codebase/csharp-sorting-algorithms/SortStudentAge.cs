using System;

class SortStudentAge
{
    static void CountingSort(int[] ages)
    {
        int minAge = 10;
        int maxAge = 18;

        int range = maxAge - minAge + 1;
        int[] count = new int[range];
        int[] output = new int[ages.Length];

        for (int i = 0; i < ages.Length; i++)
        {
            if (ages[i] < minAge || ages[i] > maxAge)
            {
                Console.WriteLine("Invalid age found: " + ages[i]);
                return;
            }
            count[ages[i] - minAge]++;
        }

        for (int i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }

        for (int i = ages.Length - 1; i >= 0; i--)
        {
            int position = count[ages[i] - minAge] - 1;
            output[position] = ages[i];
            count[ages[i] - minAge]--;
        }

        for (int i = 0; i < ages.Length; i++)
        {
            ages[i] = output[i];
        }
    }

    static void Main()
    {
        Console.Write("Enter number of students: ");
        int n = int.Parse(Console.ReadLine());

        int[] studentAges = new int[n];

        Console.WriteLine("Enter student ages (10 to 18):");
        for (int i = 0; i < n; i++)
        {
            studentAges[i] = int.Parse(Console.ReadLine());
        }

        CountingSort(studentAges);

        Console.WriteLine("\nSorted Ages:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(studentAges[i] + " ");
        }
    }
}
