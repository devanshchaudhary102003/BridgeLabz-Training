using System;
class FitnessApp
{
    public void BubbleSort(string[] user, int[] steps)
    {
        int n = steps.Length;

        for(int i = 0; i < n - 1; i++)
        {
            for(int j = i + 1; j < n; j++)
            {
                if(steps[j] > steps[i])
                {
                    int temp = steps[i];
                    steps[i] = steps[j];
                    steps[j] = temp;
                }
            }
        }
    }

    public void DisplayDetails(string[] user,int[] steps)
    {
        Console.WriteLine("Fitness Details: ");

        for(int i = 0; i < steps.Length; i++)
        {
            Console.WriteLine((i+1)+". "+user[i]+" - "+steps[i]);
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Max Length: ");
        int n = Convert.ToInt32(Console.ReadLine());

        string[] user = new string[n];
        int[] steps = new int[n];

        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("User Details: ");
            user[i] = Console.ReadLine();
        }

        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Step Details: ");
            steps[i] = Convert.ToInt32(Console.ReadLine());
        }

        FitnessApp fitnessApp = new FitnessApp();
        fitnessApp.BubbleSort(user,steps);
        fitnessApp.DisplayDetails(user,steps);
    }
}