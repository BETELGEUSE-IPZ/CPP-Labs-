using System.ComponentModel.DataAnnotations;

namespace lab6_api.Data.DTO
{
    public class ElectoralRegister
    {
        [Key]
        public long ERVoterId { get; set; }

        public string? ERAddressLine1 { get; set; }

        public string? ERAddressLine2 { get; set; }

        public string? ERCityTown { get; set; }

        public string? ERPostcode { get; set; }

        public string? EROtherDetails { get; set; }
    }
}
