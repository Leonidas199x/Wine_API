using System;

namespace Domain.WineRegion
{
    public class WineRegion
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Region.Region Region { get; set; }

        public string Note { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
