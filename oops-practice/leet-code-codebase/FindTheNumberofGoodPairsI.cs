using System;

namespace NumberOfPairsApp
{
    class FindTheNumberofGoodPairsI
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of nums1: ");
            int n1 = int.Parse(Console.ReadLine());

            int[] nums1 = new int[n1];
            Console.WriteLine("Enter elements of nums1:");
            for (int i = 0; i < n1; i++)
            {
                nums1[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter size of nums2: ");
            int n2 = int.Parse(Console.ReadLine());

            int[] nums2 = new int[n2];
            Console.WriteLine("Enter elements of nums2:");
            for (int i = 0; i < n2; i++)
            {
                nums2[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter value of k: ");
            int k = int.Parse(Console.ReadLine());

            Solution solution = new Solution();
            int result = solution.NumberOfPairs(nums1, nums2, k);

            Console.WriteLine("Number of valid pairs: " + result);
        }
    }

    public class Solution
    {
        public int NumberOfPairs(int[] nums1, int[] nums2, int k)
        {
            int count = 0;

            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    if (nums1[i] % (nums2[j] * k) == 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
