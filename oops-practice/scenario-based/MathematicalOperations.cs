using System;
public class MathematicalUtility
{
    public void Factorial()
    {
        Console.WriteLine("Enter Number:");
        int n = Convert.ToInt32(Console.ReadLine());

        int ans = 1;
        for(int i = 1; i <= n; i++)
        {
            ans = ans * i;
        }
        Console.WriteLine("Factorial of the number is :"+ans);
    }

    public void Prime()
    {
        Console.WriteLine("Enter Number:");
        int n = Convert.ToInt32(Console.ReadLine());

        if(n == 0 || n ==1)
        {
            Console.WriteLine("Not Prime");
        }
        
        int flag = 0;
        for(int i = 2; i <= n; i++)
        {
            if(n % i == 0)
            {
                flag++;
            }
        }
        if(flag == 1)
        {
            Console.WriteLine("Prime");
        }
        else
        {
            Console.WriteLine("Not Prime");
        }
    }

    public void gcd()
    {
        Console.WriteLine("Enter Number1:");
        int n1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Number1:");
        int n2 = Convert.ToInt32(Console.ReadLine());

        int highest = 1;
        int min = n1 < n2 ? n1:n2;
        for(int i = 1; i <=min; i++)
        {
            if((n1 % i == 0) && (n2 % i == 0))
            {
                highest = i;
                
            }
        }
        Console.WriteLine("GCD Of the "+n1+" and "+n2+" is "+highest);
    }

    public void Fibonacci()
    {
        Console.WriteLine("Enter Number of terms:");
        int n = Convert.ToInt32(Console.ReadLine());

        int n1 = 0;
        int n2 = 1;
        int n3;


        for(int i = 0; i < n; i++)
        {
            Console.WriteLine(n1+" ");
            n3 = n1 + n2;
            n1=n2;
            n2=n3;
        }
    }
}
class MathematicalOperations
{
    static void Main(string[] args)
    {
        MathematicalUtility obj = new MathematicalUtility();
        int choice;

        do
        {
            Console.WriteLine("-------- Mathematical Utility Menu ------------");
            Console.WriteLine("1. Factorial");
            Console.WriteLine("2. Prime Check");
            Console.WriteLine("3. GCD");
            Console.WriteLine("4. Fibonacci");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice:");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    obj.Factorial();
                    break;

                case 2:
                    obj.Prime();
                    break;

                case 3:
                    obj.gcd();
                    break;

                case 4:
                    obj.Fibonacci();
                    break;

                case 5:
                    Console.WriteLine("Existing Program....");
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }while(choice != 5);
    }
}