using System;

namespace Domain.QualityControl
{
    public class QualityControl
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Note { get; set; }

        public Country Country { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool IsNew => Id == default;
    }
}
