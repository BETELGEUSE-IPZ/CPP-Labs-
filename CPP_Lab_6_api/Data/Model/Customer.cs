namespace lab6_api.Data.Model
{
    public class Customer
    {
        public long CustomerId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? OtherDetails { get; set; }

        public string? ISOCountryCode { get; set; }

        public string? ISOCountryName { get; set; }

        public string? Country { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? AddressLine3 { get; set; }

        public string? CityTown { get; set; }

        public string? Postcode { get; set; }
    }
}
