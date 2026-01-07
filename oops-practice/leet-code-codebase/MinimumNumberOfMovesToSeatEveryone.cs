//Minimum NumberOfMovesToSeatEveryone.cs
using System;

namespace MinMovesToSeatApp
{
    class MinimumNumberOfMovesToSeatEveryone
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of seats/students: ");
            int n = int.Parse(Console.ReadLine());

            int[] seats = new int[n];
            int[] students = new int[n];

            Console.WriteLine("Enter seat positions:");
            for (int i = 0; i < n; i++)
            {
                seats[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter student positions:");
            for (int i = 0; i < n; i++)
            {
                students[i] = int.Parse(Console.ReadLine());
            }

            Solution solution = new Solution();
            int result = solution.MinMovesToSeat(seats, students);

            Console.WriteLine("Minimum moves required: " + result);
        }
    }

    public class Solution
    {
        public int MinMovesToSeat(int[] seats, int[] students)
        {
            Array.Sort(seats);
            Array.Sort(students);

            int ans = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                ans += Math.Abs(seats[i] - students[i]);
            }
            return ans;
        }
    }
}
