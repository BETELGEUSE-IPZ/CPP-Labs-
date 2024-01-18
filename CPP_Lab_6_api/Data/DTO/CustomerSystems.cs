using System.ComponentModel.DataAnnotations;

namespace lab6_api.Data.DTO
{
    public class CustomerSystems
    {
        [Key]
        public long SystemCode { get; set; }

        public string? SystemName { get; set; }
    }
}
