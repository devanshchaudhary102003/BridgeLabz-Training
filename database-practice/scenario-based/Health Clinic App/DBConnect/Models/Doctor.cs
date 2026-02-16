namespace DBConnect.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string? Name { get; set; }
        public int SpecialtyId { get; set; }   // standard name
        public long Phone { get; set; }
        public decimal ConsultationFee { get; set; }
        public bool IsActive { get; set; }
    }
}
