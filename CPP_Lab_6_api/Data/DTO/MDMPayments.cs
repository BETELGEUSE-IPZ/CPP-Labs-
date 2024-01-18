using System.ComponentModel.DataAnnotations;

namespace lab6_api.Data.DTO
{
    public class MDMPayments
    {
        [Key]
        public long MDMPaymentId { get; set; } 

        public long CustomersServiceId { get; set; }

        public long PaymentMethodCode { get; set; }

        public long PaymentStatusCode { get; set; }

        public DateTime DateOfPayment { get; set; }

        public double AmountOfPayment { get; set; }

        public string? OtherDetails { get; set; }
    }
}
