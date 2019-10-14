using System;

namespace DataContract
{
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
