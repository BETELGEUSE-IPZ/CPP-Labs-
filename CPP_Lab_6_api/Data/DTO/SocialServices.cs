using System.ComponentModel.DataAnnotations;

namespace lab6_api.Data.DTO
{
    public class SocialServices
    {
        [Key]
        public long SSClientId { get; set; }

        public string? SSOtherDetails { get; set; }
    }
}
