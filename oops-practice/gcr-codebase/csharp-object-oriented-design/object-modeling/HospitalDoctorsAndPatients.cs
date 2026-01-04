using System;
class Patient
{
    public string PatientName;

    public Patient(string patientName)
    {
        PatientName = patientName;
    }

    public void ReceiveConsultation(string doctorName)
    {
        Console.WriteLine("Patient: "+PatientName+" Consulted By Dr. "+doctorName);
    }
}

class Doctor
{
    public string DoctorName;
    public Patient[] Patients;
    public int PatientCount = 0;

    public Doctor(string doctorName,int maxPatient)
    {
        DoctorName = doctorName;
        Patients = new Patient[maxPatient];
    }

    //Communication mathod
    public void Consult(Patient patient)
    {
        if(PatientCount < Patients.Length)
        {
            Patients[PatientCount++] = patient;
            Console.WriteLine("Dr. "+DoctorName+" is consulting "+patient.PatientName);

            patient.ReceiveConsultation(DoctorName);
        }
    }

    public void ShowPatient()
    {
        Console.WriteLine("Patient of Dr. "+DoctorName+" :");
        for(int i = 0; i < PatientCount; i++)
        {
            Console.WriteLine("- "+Patients[i].PatientName);
        }
    }
}

class Hospital
{
    public string HospitalName;
    public Patient[] Patients;
    public Doctor[] Doctors;
    public int PatientCount;
    public int DoctorCount;

    public Hospital(string hospitalName,int maxPatient,int maxDoctor)
    {
        HospitalName = hospitalName;
        Patients = new Patient[maxPatient];
        Doctors = new Doctor[maxDoctor];
    }

    public void AddPatient(Patient patient)
    {
        if(PatientCount < Patients.Length)
        {
            Patients[PatientCount++] = patient;
        }
    }

    public void AddDoctor(Doctor doctor)
    {
        if(DoctorCount < Doctors.Length)
        {
            Doctors[DoctorCount++] = doctor;
        }
    }

    public void ShowHospitalDetails()
    {
        Console.WriteLine("Hospital Name: "+HospitalName);

        Console.WriteLine("\n Doctors: ");
        for(int i = 0; i < DoctorCount; i++)
        {
            Console.WriteLine("Dr. "+Doctors[i].DoctorName);
        }

        Console.WriteLine("\n Patients: ");
        for(int i = 0; i < PatientCount; i++)
        {
            Console.WriteLine("- "+Patients[i].PatientName);
        }
    }
}
class HospitalDoctorsAndPatients
{
    static void Main(string[] args)
    {
        Hospital hospital = new Hospital("ABC Hospital",3,5);

        Doctor doctor1 = new Doctor("Devansh",5);
        Doctor doctor2 = new Doctor("Rohit",5);

        Patient patient1 = new Patient("Bhanu");
        Patient patient2 = new Patient("Krishna");

        hospital.AddDoctor(doctor1);
        hospital.AddDoctor(doctor2);

        hospital.AddPatient(patient1);
        hospital.AddPatient(patient2);

        doctor1.Consult(patient1);
        doctor1.Consult(patient2);

        doctor2.Consult(patient1);

        Console.WriteLine();
        doctor1.ShowPatient();

        Console.WriteLine();
        doctor2.ShowPatient();
    }
}