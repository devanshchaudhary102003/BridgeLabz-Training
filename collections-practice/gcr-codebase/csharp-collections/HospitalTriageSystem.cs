using System;
using System.Collections.Generic;
class HospitalTriageSystem
{
    static void Main(string[] args)
    {
        //Priority Queue
        PriorityQueue<string,int> priorityQueue = new PriorityQueue<string, int>();

        priorityQueue.Enqueue("John",-3);
        priorityQueue.Enqueue("Alice",-5);
        priorityQueue.Enqueue("Bob",-2);

        Console.WriteLine("Treatment Order: ");

        while(priorityQueue.Count > 0)
        {
            string patient = priorityQueue.Dequeue();
            Console.WriteLine(patient);
        }
    }
}