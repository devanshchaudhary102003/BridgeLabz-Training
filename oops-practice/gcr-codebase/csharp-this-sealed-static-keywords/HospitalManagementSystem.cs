using System;
class Patient
{
    public static string HospitalName = "City Hospital";
    public static int TotalPatient = 0;
    public string Name;
    public int Age;
    public readonly int PatientID;
    public string Ailment;

    public Patient(string Name,int Age,string Ailment,int PatientID)
    {
        this.Name = Name;
        this.Age = Age;
        this.Ailment = Ailment;
        this.PatientID = PatientID;
        TotalPatient++;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Hospital Name:"+HospitalName);
        Console.WriteLine("Patient ID:"+PatientID);
        Console.WriteLine("Name :"+Name);
        Console.WriteLine("Age:"+Age);
        Console.WriteLine("Ailment:"+Ailment);
    }
    public static void GetTotalPatient()
    {
        Console.WriteLine("Total Patient Admitted:"+TotalPatient);
    }
}
class HospitalManagementSystem
{
    static void Main(string[] args)
    {
        Patient p1 = new Patient("Devansh",23,"Fever",2215);
        Patient p2 = new Patient("Rohit",29,"Cold",2216);

        if(p1 is Patient)
        {
            Console.WriteLine("p1 is a Patient object");
            p1.DisplayDetails();
        }

        Console.WriteLine();

        if(p2 is Patient)
        {
            Console.WriteLine("p2 is a Patient object");
            p2.DisplayDetails();
        }

        Console.WriteLine();

        Patient.GetTotalPatient();
    }
}