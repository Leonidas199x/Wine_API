using System;

namespace DataContract.Country
{
    public class Country : CountryLookup
    {
        public string CountryNote { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
