// Given the array arr consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].
//Return the array in the form [x1,y1,x2,y2,...,xn,yn].
using System;
class ShuffleTheArray
{
    static void Main(string[] args)
    {
        // Ask user to enter the total length of the array (which should be 2n)
        Console.WriteLine("Enter the Length:");
        int l = Convert.ToInt32(Console.ReadLine());

        // Create an array of size l
        int[] arr = new int[l];

        // Take input elements for the array
        for(int i = 0; i < l; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Create another array to store the shuffled result
        int[] ans = new int[arr.Length];
        // Calculate n (half of the array length)
        int n = l/2;

         // Shuffle the array:
        // First half elements (x1...xn) go to even indices
        // Second half elements (y1...yn) go to odd indices
        for(int i=0;i<n;i++){
            ans[2*i]=arr[i];
            ans[2*i+1] = arr[n+i];
        }

        // Print the shuffled array elements
        for(int i = 0; i < ans.Length; i++)
        {
            Console.WriteLine("Shuffle the Array:"+ans[i]);
        }
    }
}