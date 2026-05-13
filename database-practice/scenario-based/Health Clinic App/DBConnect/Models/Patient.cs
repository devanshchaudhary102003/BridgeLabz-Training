namespace DBConnect.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string? Name { get; set; }
        public string? DOB { get; set; }
        public long Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? BloodGroup { get; set; }
    }
}
