﻿using System;

namespace DataContract
{
    public class QualityControl
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Note { get; set; }

        public int CountryId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}