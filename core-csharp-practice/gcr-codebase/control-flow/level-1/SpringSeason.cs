using System;
class SpringSeason
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Day: ");
        int Day = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Month: ");
        int Month = Convert.ToInt32(Console.ReadLine());

        if((Month>=3 || Day>=20) && (Month<=6 || Day <= 20))
        {
            if(Day >= 1 && Day <= 31){
            Console.WriteLine("Spring Season");
            }
            else
            {
                Console.WriteLine("Invalid Date");
            }
        }
        else
        {
            Console.WriteLine("Not Spring Season");
        }
    }
}