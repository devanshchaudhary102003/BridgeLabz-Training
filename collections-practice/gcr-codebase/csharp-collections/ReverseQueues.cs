using System;
using System.Collections.Generic;
class ReverseQueues
{
    static void ReverseQueue(Queue<int> queue)
    {
        // Base Case
        if(queue.Count == 0)
        {
            return;
        }
        int front = queue.Dequeue(); // 10,20,30,40,50
        
        ReverseQueue(queue);

        queue.Enqueue(front);//50,40,30,20,10
    }
    static void Main(string[] args)
    {
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        queue.Enqueue(40);
        queue.Enqueue(50);

        ReverseQueue(queue);

        Console.WriteLine(string.Join(" ",queue));
    }
}