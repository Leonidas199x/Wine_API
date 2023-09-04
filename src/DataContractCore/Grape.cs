using System;

namespace DataContract
{
    public class Grape
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public GrapeColour Colour { get; set; }

        public string Note { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
