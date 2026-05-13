namespace DBConnect.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string? AppointmentDate { get; set; }
        public string? AppointmentTime { get; set; }

        // DB me usually string status hota (BOOKED/CANCELLED/COMPLETED)
        public string? Status { get; set; }
    }
}
