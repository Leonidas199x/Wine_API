namespace DataContract
{
    public class RetailerWineInbound
    {
        public string Name { get; set; }

        public int RetailerId { get; set; }

        public int WineId { get; set; }

        public string Description { get; set; }

        public bool Discontinued { get; set; }

        public string RetailerTasteGuide { get; set; }

        public int? StopperTypeId { get; set; }

        public string WineCode { get; set; }

        public decimal? CustomerRating { get; set; }

        public string TastingNotes { get; set; }

        public string StorageNotes { get; set; }

        public string Range { get; set; }
    }
}
