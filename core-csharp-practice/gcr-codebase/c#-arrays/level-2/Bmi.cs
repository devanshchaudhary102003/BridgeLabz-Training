using System;
class Bmi
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of persons: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[] weight = new double[n];
        double[] height = new double[n];
        double[] bmi = new double[n];
        string[] status = new string[n];

        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter the weight of "+(i+1)+" Person:");
            weight[i] = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the height of "+(i+1)+" Person:");
            height[i] = Convert.ToDouble(Console.ReadLine());
        }

        for(int i = 0; i < n; i++)
        {
            bmi[i] = weight[i] / (height[i]*height[i]);

            if(bmi[i] < 18.5)
            {
                status[i] = "UnderWeight";
            }
            else if(bmi[i] < 25)
            {
                status[i] = "Normal";
            }
            else if(bmi[i] < 30)
            {
                status[i] = "OverWeight";
            }
            else
            {
                status[i] = "Obese";
            }
        }
        for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Height of "+(i+1)+" Person:"+height[i]);
                Console.WriteLine("Weight of "+(i+1)+" Person:"+weight[i]);
                Console.WriteLine("Bmi of "+(i+1)+" Person:"+bmi[i]);
                Console.WriteLine("Status of "+(i+1)+" Person:"+status[i]);
            }
        }
    }
