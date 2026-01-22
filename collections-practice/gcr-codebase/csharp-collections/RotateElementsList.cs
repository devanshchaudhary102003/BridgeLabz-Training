using System;
using System.Collections.Generic;
class RotateElementsList
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>{10, 20, 30, 40, 50};

        int k = 2;
        int n = list.Count;

        k = k % n;  // 2 % 5 = 2

        List<int> result = new List<int>();

        // Add elements from k to end
        for(int i = k; i < n; i++)
        {
            result.Add(list[i]);
        }

        // Add first k elements
        for(int i = 0; i < k; i++)
        {
            result.Add(list[i]);
        }

        // Print result
        for(int i = 0; i < result.Count; i++)
        {
            Console.Write(result[i]+" ");
        }
    }
}