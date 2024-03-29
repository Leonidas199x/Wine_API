﻿using System;

namespace DataContract
{
    public class Region
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IsoCode { get; set; }

        public Country Country { get; set; }

        public string Note { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Latitude { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
