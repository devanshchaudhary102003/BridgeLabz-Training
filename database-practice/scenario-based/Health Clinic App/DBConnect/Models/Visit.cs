namespace DBConnect.Models
{
    public class Visit
    {
        public int VisitId { get; set; }
        public int AppointmentId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Notes { get; set; }
    }
}
