using lab6.Models.DTO;
using System.Collections.Generic;

namespace lab6.Models
{
    public class CustomerModel
    {
        public long IdToSearch { get; set; }

        public string? DateStart { get; set; } = null;

        public string? DateEnd { get; set; } = null;

        public string? Query { get; set; } = null;

        public List<Customer> Customers { get; set; }
    }
}
