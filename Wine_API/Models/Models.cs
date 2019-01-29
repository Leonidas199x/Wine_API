using System;
using System.Collections.Generic;
using System.Text;

namespace Database_Models
{
    public class Models
    {
        public class Country
        {
            public int CountryId { get; set; }

            public string CountryName { get; set; }

            public string CountryNote { get; set; }

            public DateTime DateCreated { get; set; }

            public DateTime DateUpdated { get; set; }
        }

        public class Grape
        {

            public int GrapeId { get; set; }

            public string GrapeName { get; set; }

            public int GrapeColourId { get; set; }

            public string GrapeColour { get; set; }

            public string GrapeNote { get; set; }

            public string GrapeAlternateName { get; set; }

            public DateTime DateCreated { get; set; }

            public DateTime DateUpdated { get; set; }

        }
    }
}
