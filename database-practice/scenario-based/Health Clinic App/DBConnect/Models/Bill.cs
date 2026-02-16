namespace DBConnect.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public int VisitId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? PaymentStatus { get; set; } // PENDING/PAID
    }
}
