using System;
class Youngest
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter AmarAge:");
        int AmarAge = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter AkbarAge:");
        int AkbarAge = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter AnthonyAge:");
        int AnthonyAge = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter AmarHeight:");
        int AmarHeight = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter AkbarHeight:");
        int AkbarHeight = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter AnthonyHeight:");
        int AnthonyHeight = Convert.ToInt32(Console.ReadLine());

        if((AmarAge < AkbarAge) && (AmarAge < AnthonyAge))
        {
            Console.WriteLine("Amar is Youngest");
        }
        if((AkbarAge < AmarAge) && (AkbarAge < AnthonyAge))
        {
            Console.WriteLine("Akbar is Youngest");
        }
        if((AnthonyAge < AmarAge) && (AnthonyAge < AkbarAge))
        {
            Console.WriteLine("Anthony is Youngest");
        }

        if((AmarHeight > AkbarHeight) && (AmarHeight > AkbarHeight))
        {
            Console.WriteLine("Amar is Tallest");
        }
        if((AkbarHeight > AmarHeight) && (AkbarHeight > AnthonyHeight))
        {
            Console.WriteLine("Akbar is Tallest");
        }
        if((AnthonyAge > AmarHeight) && (AnthonyAge > AkbarHeight))
        {
            Console.WriteLine("Anthony is Tallest");
        }
    }
}