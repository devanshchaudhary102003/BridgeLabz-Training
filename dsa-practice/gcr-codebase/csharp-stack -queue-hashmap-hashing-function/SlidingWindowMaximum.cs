using System;
using System.Collections.Generic;

class SlidingWindowMaximum
{
    static void Main(string[] args)
    {
        int[] arr = { 1, 3, -1, -3, 5, 3, 6, 7 };
        int k = 3;

        int[] result = MaxSlidingWindow(arr, k);

        Console.WriteLine("Sliding Window Maximums:");
        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i] + " ");
        }
    }

    static int[] MaxSlidingWindow(int[] arr, int k)
    {
        int n = arr.Length;
        int[] ans = new int[n - k + 1];
        LinkedList<int> deque = new LinkedList<int>(); // stores indices
        int index = 0;

        for (int i = 0; i < n; i++)
        {
            // Remove indices out of current window
            if (deque.Count > 0 && deque.First.Value <= i - k)
            {
                deque.RemoveFirst();
            }

            // Remove smaller elements from back
            while (deque.Count > 0 && arr[deque.Last.Value] <= arr[i])
            {
                deque.RemoveLast();
            }

            // Add current index
            deque.AddLast(i);

            // Window formed
            if (i >= k - 1)
            {
                ans[index++] = arr[deque.First.Value];
            }
        }

        return ans;
    }
}
