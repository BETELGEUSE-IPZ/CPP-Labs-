using System.ComponentModel.DataAnnotations;

namespace lab6_api.Data.DTO
{
    public class CouncilTax
    {
        [Key]
        public long CTResidentId { get; set; }

        public string? CTAddressLine1 { get; set; } 

        public string? CTAddressLine2 { get; set; }

        public string? CTAddressLine3 { get; set; }

        public string? CTCityTown { get; set; }

        public string? CTPostcode { get; set; }

        public string? CTOtherDetails { get; set; }
    }
}
