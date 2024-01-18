using lab6.Models.DTO;
using System.Collections.Generic;

namespace lab6.Models
{
    public class CountryCodeModel
    {
        public string CountryCodeToSearch { get; set; }

        public List<ISOCountryCode> ISOCountryCodes { get; set; }
    }
}
