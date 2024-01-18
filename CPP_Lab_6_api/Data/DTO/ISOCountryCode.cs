using System.ComponentModel.DataAnnotations;

namespace lab6_api.Data.DTO
{
    public class ISOCountryCode
    {
        [Key]
        public string? CountryCode { get; set; }

        public string? CountryName { get; set; }
    }
}
