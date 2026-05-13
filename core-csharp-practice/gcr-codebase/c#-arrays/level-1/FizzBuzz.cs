using System;
class FizzBuzz
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Positive Number:");
        int Number = Convert.ToInt32(Console.ReadLine());

        if(Number <= 0)
        {
            Console.WriteLine("Error:Enter a Positive Number");
        }

        string[] arr = new string[Number+1];

        for(int i = 0; i <= Number; i++)
        {
            if(i == 0)
            {
                arr[i] = "0";
            }
            else if((i % 3 == 0) && (i % 5 == 0))
            {
                arr[i] = "FizzBuzz";
            }
            else if (i % 3 == 0)
            {
                arr[i] = "Fizz";
            }
            else if(i % 5 == 0)
            {
                arr[i] = "Buzz";
            }
            else
            {
                arr[i] = i.ToString();
            }
        }

        for(int i = 0; i <= Number; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}