using System;
using System.Collections.Generic;
class GenerateBinaryNumbersUsingQueue
{
    static void GenerateBinary(int N)
    {
        Queue<string> queue = new Queue<string>();
        
        queue.Enqueue("1");

        for(int i = 1; i <= N; i++)
        {
            string current = queue.Dequeue();

            Console.Write(current + ",");

            queue.Enqueue(current + "0");
            queue.Enqueue(current + "1");
        }
    }
    static void Main(string[] args)
    {
        int N = 5;
        GenerateBinary(N);
    }
}