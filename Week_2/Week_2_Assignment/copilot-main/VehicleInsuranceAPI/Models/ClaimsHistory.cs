namespace VehicleInsuranceAPI.Models
{
    public class ClaimsHistory
    {
        public int ClaimId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
