using System;
using System.Collections.Generic;

class CircularTour
{
    static int FindStartingPump(int[] petrol, int[] distance)
    {
        int n = petrol.Length;
        Queue<int> queue = new Queue<int>();

        int balance = 0;
        int index = 0;
        int count = 0;

        while (count < 2 * n)
        {
            int diff = petrol[index] - distance[index];
            balance += diff;
            queue.Enqueue(index);

            while (balance < 0 && queue.Count > 0)
            {
                int removed = queue.Dequeue();
                balance -= (petrol[removed] - distance[removed]);
            }

            if (queue.Count == n)
            {
                return queue.Peek(); // starting pump
            }

            index = (index + 1) % n;
            count++;
        }

        return -1;
    }

    static void Main(string[] args)
    {
        int[] petrol = { 6, 3, 7 };
        int[] distance = { 4, 6, 3 };

        int start = FindStartingPump(petrol, distance);

        if (start != -1)
            Console.WriteLine("Start at petrol pump index: " + start);
        else
            Console.WriteLine("No possible circular tour");
    }
}
