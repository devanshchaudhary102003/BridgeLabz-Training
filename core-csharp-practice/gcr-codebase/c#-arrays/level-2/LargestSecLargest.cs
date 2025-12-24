using System;
class LargestSecLargest
{
    static void Main(string[] args)
    {
        int n = 10;
        int[] arr = new int[n];

        Console.WriteLine("Enter a Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        int idx = 0;

        while(Number != 0)
        {
            if(idx == n)
            {
                break;
            }
            arr[idx] = Number % 10;
            Number = Number / 10;
            idx++;
        }
        int Largest = 0;
        int SecLargest = 0;

        for(int i = 0; i < idx; i++)
        {
            if(arr[i] > Largest)
            {
                SecLargest = Largest;
                Largest = arr[i];
            }
            else if(arr[i] > SecLargest && arr[i] != Largest)
            {
                SecLargest = arr[i];
            }
        }

        Console.WriteLine("Largest Number:"+Largest);
        Console.WriteLine("Second Largest Number:"+SecLargest);
    }
}