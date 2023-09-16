using System;

namespace DataContract
{
    public class Issue
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Quantity { get; set; }

        public string Note { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
