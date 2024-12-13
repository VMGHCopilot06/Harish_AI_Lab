using System.ComponentModel.DataAnnotations;

namespace VehicleInsuranceAPI.Models
{
    public class VehicleInsuranceQuote
    {
        // Vehicle attributes
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Range(1886, 9999)]
        public int Year { get; set; }

        [Required]
        [StringLength(17, MinimumLength = 17)]
        public string VIN { get; set; }

        // Rating attributes
        [Range(0, double.MaxValue)]
        public decimal BasePremium { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Discount { get; set; }

        [Range(0, double.MaxValue)]
        public decimal FinalPremium { get; set; }

        // Customer attributes
        [Required]
        public string CustomerName { get; set; }

        [Range(18, 100)]
        public int CustomerAge { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        public int QuoteNumber { get; internal set; }
        public int Id { get; internal set; }
    }
}
