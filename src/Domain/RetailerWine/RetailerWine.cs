using System;

namespace Domain.RetailerWine
{
    public class RetailerWine
    {
        public int Id { get; set; }

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

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool IsNew => Id == default;
    }
}
