using System;
using System.CodeDom.Compiler;
using System.Security.Cryptography.X509Certificates;
class ScenarioA
{
    char[] charSet = {'a','b','c','d'};
    public void scenarioA()
    {
        Console.WriteLine("Scenario A: Generate all strings of length n.");
        Console.WriteLine("Enter Length: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Generate("",n);
    }
    public void Generate(string ans,int n)
    {
        if(ans.Length == n)
        {
            Console.WriteLine(ans);
            return;
        }

        for(int c = 0 ; c < charSet.Length ; c++)
        {
            Generate(ans+charSet[c],n);
        }
    }
}

class ScenarioB
{
    char[] charSet = {'a','b','c','d'};

    public void scenarioB()
    {
        Console.WriteLine("Scenario B: Stop if password is matched.");
        Console.WriteLine("Enter the Password made from(a,b,c,d): ");
        string password = Console.ReadLine();

        int n = charSet.Length;

        Generate("",n,password);
    }

    public void Generate(string ans,int n, string password)
    {
        if(ans.Length == n)
        {
            Console.WriteLine("Trying Password: "+ans);
            if (ans.Equals(password, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Password Cracked Successfully!");
                Console.WriteLine("Cracked Password: "+ans);
            }
            return;
        }

        for(int i = 0; i < charSet.Length; i++)
        {
            Generate(ans+charSet[i],n,password);
        }
    }
}
class PasswordCracker
{
    static void Main(string[] args)
    {
        ScenarioA scenarioA = new ScenarioA();
        scenarioA.scenarioA();

        ScenarioB scenarioB = new ScenarioB();
        scenarioB.scenarioB();
    }
}