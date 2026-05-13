using System;
class NumberGuessingGame
{
    static void Main(string[] args)
    {
        int low = 1, high = 100;
        Random random = new Random();
        string feedback;

        Console.WriteLine("Think of a number between 1 and 100");

        do
        {
            int guess = GenerateGuess(low, high, random);
            Console.WriteLine("Computer Guess: " + guess);

            feedback = GetFeedback();

            if(feedback == "low")
            {
                low = guess + 1;
            }
            else if(feedback == "high")
            {
                high = guess - 1;
            }
        } while (feedback != "correct");

        Console.WriteLine("Computer guessed correctly!");
    }

    static int GenerateGuess(int low, int high, Random r)
    {
        return r.Next(low, high + 1);
    }

    static string GetFeedback()
    {
        Console.Write("Is it high, low or correct? ");
        return Console.ReadLine().ToLower();
    
    }
}