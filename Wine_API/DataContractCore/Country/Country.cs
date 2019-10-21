// <copyright file="Country.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;

namespace DataContract.Country
{
    public class Country : CountryLookup
    {
        public string CountryNote { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
