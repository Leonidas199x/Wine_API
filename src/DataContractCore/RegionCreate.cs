namespace DataContract
{
    public class RegionCreate
    {
        public string Name { get; set; }

        public string IsoCode { get; set; }

        public int CountryId { get; set; }

        public string Note { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Latitude { get; set; }
    }
}
