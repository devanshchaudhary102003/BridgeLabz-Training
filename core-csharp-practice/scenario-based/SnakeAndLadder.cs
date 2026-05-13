using System;

class SnakeAndLadder
{
    static Random random = new Random();
    static void Main(string[] args)
    {
        Console.WriteLine("=========================================================");
        Console.WriteLine("==================== Snake & Ladder Game ================");
        Console.WriteLine("=========================================================");

        int NoOfPlayer;
        do
        {
            Console.WriteLine("Enter Number of Players(2-4):");
            NoOfPlayer = Convert.ToInt32(Console.ReadLine());
        }
        while(NoOfPlayer < 2 || NoOfPlayer > 4);

        string[] players = new string[NoOfPlayer];
        int[] positions = new int[NoOfPlayer];

        for(int i = 0; i < NoOfPlayer; i++)
        {
            Console.WriteLine("Enter name of Player "+(i+1)+": ");
            players[i] = Console.ReadLine();
            positions[i] = 0;
        }

        bool gameWon = false;

        while (!gameWon)
        {
            for(int i = 0; i < NoOfPlayer; i++)
            {
                Console.WriteLine(players[i]+"'s turn.Press Enter to roll dice...");
                Console.ReadLine();

                int dice = RollDice();
                int oldPosition = positions[i];

                Console.WriteLine("Dice Rolled:"+dice);

                if(oldPosition + dice > 100)
                {
                    Console.WriteLine("Move exceeds 100.Turn skipped");
                    continue;
                }

                int newPosition = MovePlayer(oldPosition,dice);
                newPosition = ApplySnakeOrLadder(newPosition);

                positions[i] = newPosition;
                
                Console.WriteLine(players[i] + " moved from " + oldPosition + " → " + newPosition);

                if (CheckWin(newPosition))
                {
                    Console.WriteLine(players[i]+" WINS THE GAME!");
                    gameWon = true;
                    break;
                }
            }
        }

        Console.WriteLine("\nGame Over.");
    }

    static int RollDice()
    {
        return random.Next(1,7);
    }

    static int MovePlayer(int currentPos, int dice)
    {
        return currentPos + dice;
    }

    static int ApplySnakeOrLadder(int position)
{
    
    if (position == 3)
    {
        Console.WriteLine("Ladder! 3 → 22");
        return 22;
    }
    else if (position == 5)
    {
        Console.WriteLine("Ladder! 5 → 8");
        return 8;
    }
    else if (position == 11)
    {
        Console.WriteLine("Ladder! 11 → 26");
        return 26;
    }
    else if (position == 20)
    {
        Console.WriteLine("Ladder! 20 → 29");
        return 29;
    }

    // Snakes
    else if (position == 27)
    {
        Console.WriteLine("Snake! 27 → 1");
        return 1;
    }
    else if (position == 21)
    {
        Console.WriteLine("Snake! 21 → 9");
        return 9;
    }
    else if (position == 17)
    {
        Console.WriteLine("Snake! 17 → 4");
        return 4;
    }
    else if (position == 19)
    {
        Console.WriteLine("Snake! 19 → 7");
        return 7;
    }

    // No snake or ladder
    return position;
}
    static bool CheckWin(int position)
    {
        return position == 100 ? true : false;
    }
}