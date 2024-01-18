using System.ComponentModel.DataAnnotations;

namespace lab6_api.Data.DTO
{
    public class MDMServices
    {
        [Key]
        public long ServiceId { get; set; }

        public long ServiceCategoryCode { get; set; }

        public string? ServiceName { get; set; }

        public double ServiceCost { get; set; }
        public string? ServiceDescription { get; set; }

        public string? OtherDetails { get; set; }
    }
}
