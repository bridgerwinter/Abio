using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("HiredLeaderStats", Schema = "Player")]
    public partial class HiredLeaderStat
    {
        [Key]
        public Guid HiredLeaderStatsId { get; set; }
        public Guid? HiredLeaderId { get; set; }
        public int? Leadership { get; set; }
        public int? Attack { get; set; }
        public int? Defense { get; set; }
        public int? Construction { get; set; }
        public int? ResourceProduction { get; set; }

        [ForeignKey("HiredLeaderId")]
        [InverseProperty("HiredLeaderStats")]
        public virtual HiredLeader HiredLeader { get; set; }
    }
}
