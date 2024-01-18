using System.ComponentModel.DataAnnotations;

namespace lab6_api.Data.DTO
{
    public class UKPAFFile
    {
        [Key]
        public long PafAddressId { get; set; }

        public string? CountryCode { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? AddressLine3 { get; set; }

        public string? CityTown { get; set; }

        public string? Postcode { get; set; }

        public string? Country { get; set; }
    }
}
