using System;
//Interface(Abstraction)
interface IPayable
{
    double CalculateAmount();
}
//Base Class
class Patient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Patient ID: "+PatientId);
        Console.WriteLine("Patient Name: "+Name);
        Console.WriteLine("Patient Age: "+Age);
    }
}

// Inpatient Class (Inheritance)
class Inpatient : Patient
{
    public int DaysAdmitted{ get; set; }
    public double DailyCharge{ get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Patient Type: In-Patient");
        Console.WriteLine("Days Admitted: "+DaysAdmitted);
        Console.WriteLine("Daily Charge: "+DailyCharge);
    }
}

// Outpatient Class (Inheritance)
class Outpatient : Patient
{
    public double ConsultationFee { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Patient Type: Out-Patient");
        Console.WriteLine("Consultation Fee: "+ConsultationFee);
    }
}

// Bill Class (Abstraction + Polymorphism)
class Bill : IPayable
{
    private Patient patient;

    public Bill(Patient patient)
    {
        this.patient = patient;
    }

    public double CalculateAmount()
    {
        if(patient is Inpatient)
        {
            Inpatient inpatient = (Inpatient)patient;
            return inpatient.DaysAdmitted * inpatient.DailyCharge;
        }
        else if(patient is Outpatient)
        {
            Outpatient outpatient = (Outpatient)patient;
            return outpatient.ConsultationFee;
        }
        return 0;
    }
}

class Doctor
{
    public int DoctorId { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }

    public void DisplayDoctor()
    {
        Console.WriteLine("\n Doctor ID: "+DoctorId);
        Console.WriteLine("Doctor Name: "+Name);
        Console.WriteLine("Specialization: "+Specialization);
    }
}
class HospitalPatientManagementSystem
{
    static void Main(string[] args)
    {
        Doctor doctor = new Doctor
        {
            DoctorId = 201,
            Name = "Dr. Mehta",
            Specialization = "Orthopedic"  
        };

        Patient patient1 = new Inpatient
        {
            PatientId = 1,
            Name = "Devansh",
            Age = 40,
            DaysAdmitted = 4,
            DailyCharge = 2500
        };

        Patient patient2 = new Outpatient
        {
            PatientId = 2,
            Name = "Rohit",
            Age = 48,
            ConsultationFee = 600
        };

        Bill bill1 = new Bill(patient1);
        Bill bill2 = new Bill(patient2);

        doctor.DisplayDoctor();

        Console.WriteLine("\n--- Patient Details -----");
        patient1.DisplayInfo();
        Console.WriteLine("Total Bill: "+bill1.CalculateAmount());

        Console.WriteLine("\n---------------------------");
        patient2.DisplayInfo();
        Console.WriteLine("Total Bill: "+bill2.CalculateAmount());
    }
}