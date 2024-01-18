using System.ComponentModel.DataAnnotations;

namespace lab6_api.Data.DTO
{
    public class HousingBenefits
    {
        [Key]
        public long HBRecipientId { get; set; } 

        public string? HBAddress { get; set; }

        public string? HBPostcode { get; set; }

        public string? HBOtherDetails { get; set; }
    }
}
