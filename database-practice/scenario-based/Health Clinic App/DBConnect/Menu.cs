using System;
using DBConnect.Models;
using DBConnect.Services;
using DBConnect.Interface;

namespace DBConnect
{
    public class Menu
    {
        private readonly IPatientService patientService;
        private readonly IDoctorService doctorService;
        private readonly IAppointmentService appointmentService;
        private readonly IVisitService visitService;
        private readonly IBillingService billingService;

        public Menu()
        {
            patientService = new PatientService();
            doctorService = new DoctorService();
            appointmentService = new AppointmentService();
            visitService = new VisitService();
            billingService = new BillingService();
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== HEALTH CLINIC APP =====");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. Update Patient");
                Console.WriteLine("3. Search Patient");
                Console.WriteLine("4. Add Doctor");
                Console.WriteLine("5. Book Appointment");
                Console.WriteLine("6. Cancel Appointment");
                Console.WriteLine("7. View Daily Schedule");
                Console.WriteLine("8. Record Visit");
                Console.WriteLine("9. Generate Bill");
                Console.WriteLine("10. Record Payment");
                Console.WriteLine("0. Exit");
                Console.Write("Enter Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (choice == 0)
                {
                    Console.WriteLine("Exiting Application...");
                    break;
                }

                switch (choice)
                {
                    case 1: RegisterPatient(); break;
                    case 2: UpdatePatient(); break;
                    case 3: SearchPatient(); break;
                    case 4: AddDoctor(); break;
                    case 5: BookAppointment(); break;
                    case 6: CancelAppointment(); break;
                    case 7: ViewDailySchedule(); break;
                    case 8: RecordVisit(); break;
                    case 9: GenerateBill(); break;
                    case 10: RecordPayment(); break;
                    default: Console.WriteLine("Invalid choice! Try again."); break;
                }
            }
        }

        private void RegisterPatient()
        {
            Patient p = new Patient();

            Console.Write("Name: ");
            p.Name = Console.ReadLine();

            Console.Write("DOB (yyyy-mm-dd): ");
            p.DOB = Console.ReadLine();

            Console.Write("Phone: ");
            p.Phone = long.Parse(Console.ReadLine());

            Console.Write("Email: ");
            p.Email = Console.ReadLine();

            Console.Write("Address: ");
            p.Address = Console.ReadLine();

            Console.Write("Blood Group: ");
            p.BloodGroup = Console.ReadLine();

            patientService.RegisterPatient(p);
        }

        private void UpdatePatient()
        {
            Console.Write("Patient ID: ");
            int pid = int.Parse(Console.ReadLine());

            Console.Write("New Address: ");
            string addr = Console.ReadLine();

            patientService.UpdatePatient(pid, addr);
        }

        private void SearchPatient()
        {
            Console.Write("Search Name: ");
            string name = Console.ReadLine();

            patientService.SearchPatient(name);
        }

        private void AddDoctor()
        {
            Doctor d = new Doctor();

            Console.Write("Doctor Name: ");
            d.Name = Console.ReadLine();

            Console.Write("Specialty ID: ");
            d.SpecialtyId = int.Parse(Console.ReadLine());

            Console.Write("Phone: ");
            d.Phone = long.Parse(Console.ReadLine());

            Console.Write("Fee: ");
            d.ConsultationFee = decimal.Parse(Console.ReadLine());

            doctorService.AddDoctor(d);
        }

        private void BookAppointment()
        {
            Console.Write("Patient ID: ");
            int pId = int.Parse(Console.ReadLine());

            Console.Write("Doctor ID: ");
            int dId = int.Parse(Console.ReadLine());

            Console.Write("Date (yyyy-mm-dd): ");
            string date = Console.ReadLine();

            Console.Write("Time (HH:mm): ");
            string time = Console.ReadLine();

            appointmentService.BookAppointment(pId, dId, date, time);
        }

        private void CancelAppointment()
        {
            Console.Write("Appointment ID: ");
            int aId = int.Parse(Console.ReadLine());

            appointmentService.CancelAppointment(aId);
        }

        private void ViewDailySchedule()
        {
            Console.Write("Date (yyyy-mm-dd): ");
            string date = Console.ReadLine();

            appointmentService.ViewDailySchedule(date);
        }

        private void RecordVisit()
        {
            Console.Write("Appointment ID: ");
            int apId = int.Parse(Console.ReadLine());

            Console.Write("Diagnosis: ");
            string diag = Console.ReadLine();

            Console.Write("Notes: ");
            string notes = Console.ReadLine();

            visitService.RecordVisit(apId, diag, notes);
        }

        private void GenerateBill()
        {
            Console.Write("Visit ID: ");
            int vId = int.Parse(Console.ReadLine());

            Console.Write("Amount: ");
            decimal amt = decimal.Parse(Console.ReadLine());

            billingService.GenerateBill(vId, amt);
        }

        private void RecordPayment()
        {
            Console.Write("Bill ID: ");
            int bId = int.Parse(Console.ReadLine());

            billingService.RecordPayment(bId);
        }
    }
}
