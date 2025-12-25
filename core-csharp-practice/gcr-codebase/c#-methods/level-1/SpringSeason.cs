using System;
class SpringSeason
{
    static void Main(string[] args)
    {
        if(args.Length != 2)
        {
            Console.WriteLine("Enter Month and Day as command line argument.");
            return;
        }

        int month = Convert.ToInt32(args[0]);
        int day = Convert.ToInt32(args[1]);

        bool isSpring = CheckSpringSeason(month,day);

        if (isSpring)
        {
            Console.WriteLine("Its a Spring Season");
        }
        else
        {
            Console.WriteLine("Its Not a Spring Season");
        }
    }
    static bool CheckSpringSeason(int month,int day)
    {
        if((month == 3 && day >= 20) || (month == 4) || (month == 5) || (month == 6 && day <= 20))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}