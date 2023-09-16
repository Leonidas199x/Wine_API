using System;
using System.Collections.Generic;

namespace DataContract
{
    public class Wine
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public Producer Producer { get; set; }

        public Region Region { get; set; }

        public int Vintage { get; set; }

        public QualityControl QualityControl { get; set; }

        public VineyardEstate VineyardEstate { get; set; }

        public WineType WineType { get; set; }

        public decimal Abv { get; set; }

        public string Importer { get; set; }

        public int InventoryLevel { get; set; }

        public Retailer ExclusiveRetailer { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public IEnumerable<WineRating> Ratings { get; set; }

        public IEnumerable<Grape> Grapes { get; set; }

        public IEnumerable<WinePrice> Prices { get; set; }

        public IEnumerable<Issue> Issues { get; set; }

        public IEnumerable<Receipt> Receipts { get; set; }
    }
}
