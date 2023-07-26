using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("HiredLeaders", Schema = "Player")]
    public partial class HiredLeader
    {
        public HiredLeader()
        {
            HiredLeaderStats = new HashSet<HiredLeaderStat>();
            HiredUnits = new HashSet<HiredUnit>();
            UnitGroups = new HashSet<UnitGroup>();
            UserCitiesLeaders = new HashSet<UserCitiesLeader>();
        }

        [Key]
        public Guid HiredLeaderId { get; set; }
        public Guid? UserId { get; set; }
        [StringLength(24)]
        [Unicode(false)]
        public string HiredLeaderName { get; set; }
        public Guid? LeaderStatId { get; set; }
        [Required]
        [Column("created_at")]
        public byte[] CreatedAt { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("HiredLeaders")]
        public virtual User User { get; set; }
        [InverseProperty("HiredLeader")]
        public virtual ICollection<HiredLeaderStat> HiredLeaderStats { get; set; }
        [InverseProperty("HiredLeader")]
        public virtual ICollection<HiredUnit> HiredUnits { get; set; }
        [InverseProperty("HiredLeader")]
        public virtual ICollection<UnitGroup> UnitGroups { get; set; }
        [InverseProperty("HiredLeader")]
        public virtual ICollection<UserCitiesLeader> UserCitiesLeaders { get; set; }
    }
}
