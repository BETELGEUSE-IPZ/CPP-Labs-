using System.ComponentModel.DataAnnotations;

namespace lab6_api.Data.DTO
{
    public class ParkingTickets
    {
        [Key]
        public long PTOffenderId { get; set; }

        public string? PTAddress { get; set; }

        public string? PTOtherDetails { get; set; } 
    }
}
