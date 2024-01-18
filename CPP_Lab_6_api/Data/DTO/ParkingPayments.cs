using System.ComponentModel.DataAnnotations;

namespace lab6_api.Data.DTO
{
    public class ParkingPayments
    {
        [Key]
        public long PaymentId { get; set; }

        public long PTOffenderId { get; set; }

        public long PaymentMethodCode { get; set; }

        public DateTime DateOfPayment { get; set; } 

        public double AmountOfPayment { get; set; }

        public string? OtherDetails { get; set; }
    }
}
