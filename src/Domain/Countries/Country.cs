using System;

namespace Domain
{
    public class Country : CountryLookup
    {
        public string IsoCode { get; set; }

        public string Note { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool IsNew => Id == default;
    }
}
