using System;

namespace DataContract
{
    public class Retailer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? MinimumPurchaseQuantity { get; set; }

        public int? IncrementQuantity { get; set; }

        public decimal? GenericDiscountPercentage { get; set; }

        public string GenericDiscountName { get; set; }

        public string WebsiteUrl { get; set; }

        public int? WebsiteRating { get; set; }

        public int? OrderRating { get; set; }

        public int? DeliveryRating { get; set; }

        public int? MaxCustomerRating { get; set; }

        public string Note { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
