using System;
interface IMedicalRecord
{
    void AddRecord(string diagnosis, string history);
    void ViewRecords();
}
abstract class Patient
{
    private int patientId;
    private string patientName;
    private int patientAge;

    public int PatientId
    {
        get
        {
            return patientId;
        }
        set
        {
            patientId = value;
        }
    }

    public string PatientName
    {
        get
        {
            return patientName;
        }
        set
        {
            patientName = value;
        }
    }

    public int PatientAge
    {
        get
        {
            return patientAge;
        }
        set
        {
            patientAge = value;
        }
    }

    public abstract int CalculateBill();

    public void GetPatientDetails()
    {
        Console.WriteLine("Patient Id: "+PatientId);
        Console.WriteLine("Patient Name: "+PatientName);
        Console.WriteLine("Patient Age: "+PatientAge);
        Console.WriteLine("Patient Total Bill: "+CalculateBill());
    }
}

class InPatient : Patient,IMedicalRecord
{
    private string diagnosis;
    private string medicalHistory;

    public int DaysAdmitted { get; set; }
    public double dailyCharge = 2000;

    public override int CalculateBill()
    {
        return (int)(dailyCharge * DaysAdmitted);
    }

    public void AddRecord(string diagnosis,string history)
    {
        this.diagnosis = diagnosis;
        this.medicalHistory = history;
    }

    public void ViewRecords()
    {
        Console.WriteLine("Diagnosis: "+diagnosis);
        Console.WriteLine("Medical History: "+medicalHistory);
    }
}

class OutPatient : Patient,IMedicalRecord
{
    private string diagnosis;
    private string medicalHistory;
    private double consultationFee = 500;

    public override int CalculateBill()
    {
        return (int)consultationFee;
    }
    
    public void AddRecord(string diagnosis,string history)
    {
        this.diagnosis = diagnosis;
        this.medicalHistory = history;
    }

    public void ViewRecords()
    {
        Console.WriteLine("Diagnosis: "+diagnosis);
    }
       
}
class HospitalPatientManagement
{
    static void Main(string[] args)
    {
        Patient[] patient = new Patient[2];

        patient[0] = new InPatient();
        patient[0].PatientId = 101;
        patient[0].PatientName = "Devansh";
        patient[0].PatientAge = 22;
        ((InPatient)patient[0]).DaysAdmitted = 3; 
        ((IMedicalRecord)patient[0]).AddRecord("Fever","Admitted for observation");

        patient[1] = new OutPatient();
        patient[1].PatientId = 102;
        patient[1].PatientName = "Rohit";
        patient[1].PatientAge = 25;
        ((IMedicalRecord)patient[1]).AddRecord("Fracture", "Surgery done");

        for(int i = 0; i < patient.Length; i++)
        {
            Console.WriteLine("---------------------------------------");
            patient[i].GetPatientDetails();

            ((IMedicalRecord)patient[i]).ViewRecords();
        }
    }
}