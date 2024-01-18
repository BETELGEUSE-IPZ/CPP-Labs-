using System.ComponentModel.DataAnnotations;

namespace lab6_api.Data.DTO
{
    public class MDMCustomerIndex
    {
        [Key]
        public long MDMCustomerId { get; set; }

        public long SystemCode { get; set; }

        public long SystemCustomerId { get; set; }
    }
}
