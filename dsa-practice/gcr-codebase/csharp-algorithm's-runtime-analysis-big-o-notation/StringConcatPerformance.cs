using System;
using System.Diagnostics;
using System.Text;

namespace StringConcatPerformance
{
    class Program
    {
        static void Main()
        {
            int[] testSizes = { 1000, 10000, 1000000 };

            for (int i = 0; i < testSizes.Length; i++)
            {
                int n = testSizes[i];

                Console.WriteLine("\nOperations Count (N) = " + n);

                TestStringConcatenation(n);
                TestStringBuilderConcatenation(n);
            }

            Console.WriteLine("\nBenchmark completed.");
            Console.ReadLine();
        }

        // O(N²) – string (immutable)
        static void TestStringConcatenation(int n)
        {
            Stopwatch sw = Stopwatch.StartNew();

            string result = "";
            for (int i = 0; i < n; i++)
            {
                result = result + "A";
            }

            sw.Stop();
            Console.WriteLine("String Time        : " + sw.ElapsedMilliseconds + " ms");
        }

        // O(N) – StringBuilder (mutable)
        static void TestStringBuilderConcatenation(int n)
        {
            Stopwatch sw = Stopwatch.StartNew();

            StringBuilder sb = new StringBuilder(n);
            for (int i = 0; i < n; i++)
            {
                sb.Append("A");
            }

            sw.Stop();
            Console.WriteLine("StringBuilder Time : " + sw.ElapsedMilliseconds + " ms");
        }
    }
}
