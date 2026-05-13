using System;
using System.Security.Cryptography.X509Certificates;

// ---------------- STACK IMPLEMENTATION ----------------
class QuestionStack
{
    private int[] stack;
    private int size;
    private int top;

    public QuestionStack(int size)
    {
        this.size = size;
        stack = new int[size];
        top = -1;
    }

    public void Push(int questionId)
    {
        if(top == size - 1)
        {
            Console.WriteLine("Navigation Stack Overflow!");
            return;
        }

        stack[++top] = questionId;
    }

    public int Pop()
    {
        if(top == -1)
        {
            Console.WriteLine("No Previous Question!");
            return -1;
        }
        return stack[top--];
    }

    public void Display()
    {
        Console.WriteLine("Visited Questions: ");

        for(int i = 0; i <= top; i++)
        {
            Console.WriteLine(stack[i]+" ");
        }
        Console.WriteLine();
    }
}

// ---------------- HASHMAP IMPLEMENTATION ----------------
class AnswerMap
{
    private string[] values;
    private int[] keys;
    private int size;

    public AnswerMap(int size)
    {
        this.size = size;
        values = new string[size];
        keys = new int[size];

        for(int i = 0; i < size; i++)
        {
            keys[i] = -1;
        }
    }

    private int Hash(int key)
    {
        return key % size;
    }

    public void Put(int questionId, string answer)
    {
        int index = Hash(questionId);

        while(keys[index] != -1 && keys[index] != questionId)
        {
            index = (index + 1) % size;
        }

        keys[index] = questionId;
        values[index] = answer;
    }

    public string Get(int questionId)
    {
        int index = Hash(questionId);

        while(keys[index] != -1)
        {
            if(keys[index] == questionId)
            {
                return values[index];
            }

            index = (index + 1) % size;
        }
        return null;
    }
}

class ExamProctor
{
    static int[] question = { 101, 102, 103, 104, 105 };
    static string[] correctAnswers = { "A", "C", "B", "D", "C" };

    static QuestionStack navigationStack = new QuestionStack(10);
    static AnswerMap answerMap = new AnswerMap(10);

    static void VisitQuestion(int qid)
    {
        navigationStack.Push(qid);
        Console.WriteLine("Visited Question: "+qid);
    }

    static void SubmitAnswer(int qid, string answer)
    {
        answerMap.Put(qid,answer);
        Console.WriteLine("Answer Saved.");
    }

    static void EvaluateExam()
    {
        int score = 0;

        for(int i = 0; i < question.Length; i++)
        {
            string ans = answerMap.Get(question[i]);

            if(ans != null && ans == correctAnswers[i])
            {
                score++;
            }
        }
        Console.WriteLine("\nFinal Score: "+score+"/"+question.Length);
    }
    static void Main(string[] args)
    {
        int choice ;

        do
        {
            Console.WriteLine("\n============== Exam Proctor System =============");
            Console.WriteLine("1. Visit Question");
            Console.WriteLine("2. Submit Question");
            Console.WriteLine("3. Go Back(Stack Pop)");
            Console.WriteLine("4. View Navigation");
            Console.WriteLine("5. Submit Exam");
            Console.WriteLine("0. Exit");

            Console.WriteLine("Enter Choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Question Id: ");
                    VisitQuestion(Convert.ToInt32(Console.ReadLine()));
                    break;

                case 2:
                    Console.WriteLine("Enter Question Id: ");
                    int qid = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Answer: ");
                    SubmitAnswer(qid,Console.ReadLine().ToUpper());
                    break;

                case 3:
                    int prev = navigationStack.Pop();
                    if(prev != -1)
                        Console.WriteLine("Back To Question: "+prev);
                    break;

                case 4:
                    navigationStack.Display();
                    break;

                case 0:
                    EvaluateExam();
                    break;
            }
        }while(choice != 0); 
    }
}