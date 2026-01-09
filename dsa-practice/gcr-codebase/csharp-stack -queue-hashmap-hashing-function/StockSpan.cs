using System;
using System.Collections.Generic;

class StockSpan
{
    static void Main(string[] args)
    {
        int[] prices = { 100, 80, 60, 70, 60, 75, 85 };
        int n = prices.Length;

        int[] span = CalculateSpan(prices, n);

        Console.WriteLine("Stock Prices:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(prices[i] + " ");
        }

        Console.WriteLine("\n\nStock Span:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(span[i] + " ");
        }
    }

    static int[] CalculateSpan(int[] prices, int n)
    {
        int[] span = new int[n];
        Stack<int> st = new Stack<int>();

        // First day span is always 1
        span[0] = 1;
        st.Push(0);

        for (int i = 1; i < n; i++)
        {
            // Pop while current price is higher
            while (st.Count > 0 && prices[st.Peek()] <= prices[i])
            {
                st.Pop();
            }

            span[i] = (st.Count == 0) ? (i + 1) : (i - st.Peek());

            st.Push(i);
        }

        return span;
    }
}
