using System;

namespace Domain.Countries
{
    public class Country : CountryLookup
    {
        public string Note { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
