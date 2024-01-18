using System.ComponentModel.DataAnnotations;

namespace lab6_api.Data.DTO
{
    public class MDMCustomersServices
    {
        [Key]
        public long CustomersServiceId { get; set; }

        public long MDMCustomerId { get; set; }

        public long ServiceId { get; set; }

        public DateTime DateServiceRequested { get; set; }

        public DateTime DateServiceReceived { get; set; }

        public double CostOfService { get; set; }

        public string? OtherDetails { get; set; }
    }
}
