using System;
class SumOfAllNumber
{
    static void Main(string[] args)
    {
        double sum = 0.0;
        double[] arr = new double[10];
        
        int i = 0;
        while (true)
        {
            Console.WriteLine("Enter a Number:");
            arr[i] = Convert.ToDouble(Console.ReadLine());

            if(arr[i] <= 0)
            {
                break;
            }
            if(arr[i] == 10)
            {
                break;
            }
            i++;
        }
        
        for(int j = 0; j < i; j++)
        {
            Console.WriteLine(arr[j]);
            sum += arr[j];
        }
        Console.WriteLine("Total Sum:"+sum);
    }
}
