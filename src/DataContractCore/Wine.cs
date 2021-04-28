using System;
using System.Collections.Generic;

namespace DataContract
{
    public class Wine
    {
        public int Id { get; set; }

        public int ProducerId { get; set; }

        public int RegionId { get; set; }

        public int Vintage { get; set; }

        public int QualityControlId { get; set; }

        public int VineyardEstateId { get; set; }

        public int WineTypeId { get; set; }

        public string Description { get; set; }

        public decimal Abv { get; set; }

        public string Importer { get; set; }

        public int InventoryLevel { get; set; }

        public int ExclusiveRetailerId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public IEnumerable<WineRating> Ratings { get; set; }

        public IEnumerable<Grape> Grapes { get; set; }

        public IEnumerable<WinePrice> Prices { get; set; }

        public IEnumerable<Issue> Issues { get; set; }

        public IEnumerable<Receipt> Receipts { get; set; }
    }
}
