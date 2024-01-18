using System.ComponentModel.DataAnnotations;

namespace lab6_api.Data.DTO
{
    public class MDMCustomer
    {
        [Key]
        public long MDMCustomerId { get; set; }

        public long PAFAddressId { get; set; }

        public DateTime MDMDateOfBirth { get; set; }

        public string? OtherDetails { get; set; }
    }
}
