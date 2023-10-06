using System;
using System.Collections.Generic;
using Domain.Rating;

namespace Domain.Wine
{
    public class Wine
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Vintage { get; set; }

        public decimal Abv { get; set; }

        public string Importer { get; set; }

        public int InventoryLevel { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public Producer.Producer Producer { get; set; }

        public Region.Region Region { get; set; }

        public QualityControl.QualityControl QualityControl { get; set; }

        public VineyardEstate.VineyardEstate VineyardEstate { get; set; }

        public WineType.WineType WineType { get; set; }

        public Retailer.Retailer ExclusiveRetailer { get; set; }

        public IEnumerable<WineRating> Ratings { get; set; }

        public IEnumerable<Grape> Grapes { get; set; }

        public IEnumerable<Issue.Issue> Issues { get; set; }
    }
}
