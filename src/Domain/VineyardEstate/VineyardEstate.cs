using System;

namespace Domain.VineyardEstate
{
    public class VineyardEstate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Note { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Latitude { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool IsNew => Id == default;
    }
}
