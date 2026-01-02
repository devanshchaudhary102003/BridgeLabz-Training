using System;

class LuckyDraw
{
    public void StartDraw()
    {
        while (true)
        {
            Console.Write("Enter lucky number (enter 0 to stop): ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number == 0)
                break;

            if (number < 0)
            {
                Console.WriteLine("Invalid number! Try again.");
                continue;
            }

            CheckWinner(number);
        }

        Console.WriteLine("Lucky Draw Closed.");
    }

    private void CheckWinner(int number)
    {
        if (number % 3 == 0 && number % 5 == 0)
        {
            Console.WriteLine("🎉 Congratulations! You won a gift!");
        }
        else
        {
            Console.WriteLine("Sorry! Better luck next time.");
        }
    }
}

class FestivalLuckyDraw
{
    static void Main()
    {
        LuckyDraw draw = new LuckyDraw();
        draw.StartDraw();
    }
}
