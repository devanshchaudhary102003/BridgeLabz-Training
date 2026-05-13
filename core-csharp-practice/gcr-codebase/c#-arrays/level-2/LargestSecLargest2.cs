using System;
class LargestSecLargest2
{
    static void Main(string[] args)
    {
        int n = 10;
        int[] arr = new int[n];

        Console.WriteLine("Enter a Number:");
        long Number = Convert.ToInt64(Console.ReadLine());

        int idx = 0;

        while(Number != 0)
        {
            if(idx == n)
            {
                n += 10;
                int[] temp = new int[n];

                for(int i = 0; i < arr.Length; i++)
                {
                    temp[i] = arr[i];
                }
                arr = temp;
            }
            arr[idx] = (int)Number % 10;
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