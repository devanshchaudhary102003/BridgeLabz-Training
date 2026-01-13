/*● Applicant class: name, creditScore, income, loanAmount.
● LoanApplication class with loan type, term, and interest rate.
● Interface IApprovable with approveLoan() and calculateEMI().
● Use constructors to support different types of loans (personal, home, auto).
● Operators for EMI calculation: P × R × (1+R)^N / ((1+R)^N – 1)
● Encapsulation: keep credit score and internal approval logic public.
● Inheritance: different loan types (HomeLoan, AutoLoan) extending base class.
● Polymorphism: EMI calculation logic varies by loan type.
● Access modifiers to limit loan status changes to internal processes only.*/

using System;
// ================= INTERFACE =================
interface IApprovable
{
    bool ApproveLoan();
    double CalculateEMI();
}
// ================= APPLICANT CLASS =================
class Applicant
{
    public string Name { get; private set; }
    private int CreditScore;        //Encapsulation
    public double Income { get; private set; }
    public double LoanAmount { get; private set; }

    public Applicant(string name,int CreditScore,int income,int loanAmount)
    {
        Name = name;
        this.CreditScore = CreditScore;
        Income = income;
        LoanAmount = loanAmount;
    }

    internal int GetCreditScore()
    {
        return CreditScore; //controlled score
    }
}

abstract class LoanApplication : IApprovable
{
    protected Applicant Applicant;
    protected int Term;         // months
    protected double InterestRate;  //annual %

    private bool LoanStatus;        //cannot be modified outside

    protected LoanApplication(Applicant Applicant,int Term, double InterestRate)
    {
        this.Applicant = Applicant;
        this.Term = Term;
        this.InterestRate = InterestRate;
    }

    public bool ApproveLoan()
    {
        // Internal approval logic (hidden)
        if(Applicant.GetCreditScore() >= 650 && Applicant.Income >= Applicant.LoanAmount / 10)
        {
            LoanStatus = true;
        }
        else
        {
            LoanStatus = false;
        }

        return LoanStatus;
    }

    public abstract double CalculateEMI();
}

// ================= HOME LOAN =================
class HomeLoan : LoanApplication
{
    public HomeLoan(Applicant applicant, int term):base(applicant,term,8.5){}

    public override double CalculateEMI()
    {
        double P = Applicant.LoanAmount;
        double R = InterestRate / (12 * 100);
        int N = Term;

        return (P * R * Math.Pow(1 + R, N)) / (Math.Pow(1 + R, N) - 1);
    }
}

// ================= AUTO LOAN =================
class AutoLoan : LoanApplication
{
    public AutoLoan(Applicant applicant, int term):base(applicant,term,10.5){}

    public override double CalculateEMI()
    {
        double P = Applicant.LoanAmount;
        double R = InterestRate / (12 * 100);
        int N = Term;

        return ((P * R * Math.Pow(1 + R, N)) / (Math.Pow(1 + R, N) - 1)) + 200;
    }
}
class LoanBuddy
{
    static void Main(string[] args)
    {
        Applicant applicant = new Applicant("Devansh",720,80000,500000);

        LoanApplication loan;

        // Polymorphism
        //loan = new HomeLoan(applicant, 240);
         loan = new AutoLoan(applicant, 60);

        
        Console.WriteLine("Applicant Name: " + applicant.Name);
        Console.WriteLine("Loan Approved: " + loan.ApproveLoan());

        if (loan.ApproveLoan())
            {
                Console.WriteLine("Monthly EMI: ₹" + Math.Round(loan.CalculateEMI(), 2));
            }
            else
            {
                Console.WriteLine("Loan Rejected");
            }

    }
}