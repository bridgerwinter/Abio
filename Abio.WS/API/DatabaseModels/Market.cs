﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("Markets", Schema = "Economy")]
    public partial class Market
    {
        public Market()
        {
            MarketListings = new HashSet<MarketListing>();
        }

        [Key]
        public Guid MarketId { get; set; }
        public long? MarketCoordinatesX { get; set; }
        public long? MarketCoordinatesY { get; set; }
        public int? MarketRadius { get; set; }
        [Unicode(false)]
        public string MarketName { get; set; }
        public bool? IsMainMarket { get; set; }

        [InverseProperty("Market")]
        public virtual ICollection<MarketListing> MarketListings { get; set; }
    }
}
