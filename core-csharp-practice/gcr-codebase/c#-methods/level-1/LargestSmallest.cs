using System;
class LargestSmallest
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Number1:");
        int n1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter a Number2:");
        int n2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter a Number3:");
        int n3 = Convert.ToInt32(Console.ReadLine());

        int[] result = FindSmallestAndLargest(n1,n2,n3);

        Console.WriteLine("Smallest Number:"+result[0]);
        Console.WriteLine("Largest Number:"+result[1]);

    }
    public static int[] FindSmallestAndLargest(int n1,int n2, int n3)
    {
    
        int smallest = n1;
        int largest = n1;

        if(n2 < smallest)
        {
            smallest = n2;
        }
        if(n3 < smallest)
        {
            smallest = n3;
        }
        if(n2 > largest)
        {
            largest = n2;
        }
        if(n2 > largest)
        {
            largest = n2;
        }

        return new int[] { smallest, largest };
    }
}