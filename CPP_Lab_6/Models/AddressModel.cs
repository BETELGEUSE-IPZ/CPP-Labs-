using lab6.Models.DTO;
using System.Collections.Generic;

namespace lab6.Models
{
    public class AddressModel
    {
        public int IdToSearch { get; set; }

        public List<UKPAFFile> Files { get; set; }
    }
}
