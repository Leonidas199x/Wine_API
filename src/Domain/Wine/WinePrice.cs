using System;

namespace Domain.Wine
{
    public class WinePrice
    {
        public int Id { get; set; }

        public int WineId { get; set; }

        public DateTime EffectiveDate { get; set; }

        public decimal FullPrice { get; set; }

        public decimal DiscountedPrice { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public decimal DiscountedPercentage => (((DiscountedPrice - FullPrice) / FullPrice) * 100);
    }
}
