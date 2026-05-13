using System;
class EduQuiz
{
    static void Main(string[] args)
    {
        string[,] questions =
        {
            {
                "What is the correct file extension for a C# source file?",
                "A) .java", "B) .cpp", "C) .cs", "D) .c"
            },
            {
                "Which keyword is used to declare a class in C#?",
                "A) struct", "B) class", "C) object", "D) new"
            },
            {
                "Which of the following is a value type in C#?",
                "A) string", "B) array", "C) int", "D) object"
            },
            {
                "Which loop is guaranteed to execute at least once?",
                "A) for", "B) while", "C) foreach", "D) do-while"
            },
            {
                "Which symbol is used to end a statement in C#?",
                "A) :", "B) .", "C) ;", "D) ,"
            },
            {
                "Which method is used to take input from the console?",
                "A) Console.Write()", "B) Console.ReadLine()", "C) Console.Read()", "D) Console.Input()"
            },
            {
                "What is the default value of a bool variable?",
                "A) true", "B) false", "C) 0", "D) null"
            },
            {
                "Which keyword is used to stop a loop?",
                "A) continue", "B) return", "C) exit", "D) break"
            },
            {
                "Which data type is used to store text in C#?",
                "A) char", "B) string", "C) text", "D) varchar"
            },
            {
                "Which access modifier makes members accessible everywhere?",
                "A) private", "B) protected", "C) internal", "D) public"
            }
        };

        //correct answers
        string[] answer = {"C","B","C","D","C","B","B","D","B","D"};

        //student answer
        string[] StudentAnswer = new string[10];

        Console.WriteLine("============= EduQuiz =============");

        for(int i = 0; i < questions.GetLength(0); i++)
        {
            Console.WriteLine((i+1)+". "+questions[i,0]);
            Console.WriteLine(questions[i,1]);
            Console.WriteLine(questions[i,2]);
            Console.WriteLine(questions[i,3]);
            Console.WriteLine(questions[i,4]);

            Console.WriteLine("Your Answer: ");
            StudentAnswer[i] = Console.ReadLine();
            Console.WriteLine();
        }

        int score = CalculateScore(answer,StudentAnswer);

        Console.WriteLine("Final Score: "+ score + " / 10");

        double percentage = (score * 100) / 10.0;
        Console.WriteLine("Percentage: "+percentage+"%");

        if(percentage >= 50)
        {
            Console.WriteLine("Result: Pass");
        }
        else
        {
            Console.WriteLine("Result: Fail");
        }
    }

    static int CalculateScore(string[] correct, string[] student)
    {
        int score = 0;

        Console.WriteLine("------------Quiz Feedback----------");

        for(int i = 0; i < correct.Length; i++)
        {
            if(correct[i].ToLower() == student[i].ToLower())
            {
                Console.WriteLine("Question "+(i+1)+": Correct");
                score++;
            }
            else
            {
                Console.WriteLine("Question "+(i+1)+": Incorrect");
            }
        }
        return score;
    }
}