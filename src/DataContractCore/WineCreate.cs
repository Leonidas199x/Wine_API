namespace DataContract
{
    public class WineCreate
    {
        public string Description { get; set; }

        public int? ProducerId { get; set; }

        public int RegionId { get; set; }

        public int? Vintage { get; set; }

        public int? QualityControlId { get; set; }

        public int? VineyardEstateId { get; set; }

        public int WineTypeId { get; set; }

        public int Abv { get; set; }

        public string Importer { get; set; }

        public int? InventoryLevel { get; set; }

        public int? ExclusiveToRetailerId { get; set; }
    }
}
