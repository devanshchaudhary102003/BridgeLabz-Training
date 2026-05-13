using System;

class Calendar
{
    static void Main(string[] args)
    {
        Console.Write("Enter month: ");
        int month = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        DisplayCalendar(month, year);
    }

    public static string GetMonthName(int month)
    {
        string[] monthNames = { "January", "February", "March", "April", "May", "June","July", "August", "September", "October", "November", "December" };
        if(month >= 1 && month <= 12)
        {
            return monthNames[month - 1];
        }
        else
        {
            return "Invalid Month";
        }
    }

    public static int GetDaysInMonth(int month, int year)
    {
        int[] daysInMonth = { 31, 28, 31, 30, 31, 30,31, 31, 30, 31, 30, 31 };

        if(month == 2 && IsLeapYear(year))
        {
            return 29;
        }
        else
        {
            return daysInMonth[month - 1];
        }
    }

    public static bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }

    public static int GetFirstDayOfMonth(int month, int year)
    {
        int y0 = year - (14 - month) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = month + 12 * ((14 - month) / 12) - 2;
        int d0 = (1 + x + (31 * m0) / 12) % 7;
        return d0;
    }

    public static void DisplayCalendar(int month, int year)
    {
        string monthName = GetMonthName(month);
        int days = GetDaysInMonth(month, year);
        int firstDay = GetFirstDayOfMonth(month, year);

        Console.WriteLine("\n   " + monthName + " " + year);
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

        for (int i = 0; i < firstDay; i++)
            Console.Write("    ");

        for (int day = 1; day <= days; day++)
        {
            Console.Write("{0,3} ", day);

            if ((day + firstDay) % 7 == 0)
                Console.WriteLine();
        }
        Console.WriteLine();
    }
}
