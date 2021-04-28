using System;

namespace Domain.Receipt
{
    public class Receipt
    {
        public int Id { get; set; }

        public int WineId { get; set; }

        public int RetailerId { get; set; }

        public DateTime Date { get; set; }

        public int Quantity { get; set; }

        public string Note { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool IsNew => Id == default;
    }
}
