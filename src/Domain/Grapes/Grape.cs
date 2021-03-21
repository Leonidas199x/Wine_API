using System;

namespace Domain.Grapes
{
    public class Grape
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GrapeColourId { get; set; }

        public string GrapeColour { get; set; }

        public string Note { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
