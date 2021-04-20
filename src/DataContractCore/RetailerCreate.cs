namespace DataContract
{
    public class RetailerCreate
    {
        public string Name { get; set; }

        public int MinimumPurchaseQuantity { get; set; }

        public int IncrementQuantity { get; set; }

        public decimal GenericDiscountPercentage { get; set; }

        public string GenericDiscountName { get; set; }

        public string WebsiteUrl { get; set; }

        public int WebsiteRating { get; set; }

        public int OrderRating { get; set; }

        public int DeliveryRating { get; set; }

        public int MaxCustomerRating { get; set; }

        public string Note { get; set; }
    }
}
