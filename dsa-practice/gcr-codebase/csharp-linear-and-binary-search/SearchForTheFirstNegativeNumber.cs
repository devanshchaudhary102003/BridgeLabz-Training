using System;
class SearchForTheFirstNegativeNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the length: ");
        int length = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[length];

        for(int i = 0; i < length; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }


        for(int i = 0; i < arr.Length; i++)
        {
            if(arr[i] < 0)
            {
                Console.WriteLine("First Negative Number: "+arr[i]);
                break;
            }
        }
    }
}