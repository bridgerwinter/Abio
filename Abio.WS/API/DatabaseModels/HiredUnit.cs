using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("HiredUnits", Schema = "Player")]
    public partial class HiredUnit
    {
        public HiredUnit()
        {
            HiredUnitsStats = new HashSet<HiredUnitsStat>();
            UnitGroups = new HashSet<UnitGroup>();
        }

        [Key]
        public Guid HiredUnitId { get; set; }
        public Guid? UserId { get; set; }
        public int? UnitId { get; set; }
        public int? UnitLevel { get; set; }
        public Guid? HiredLeaderId { get; set; }
        [Required]
        [Column("created_at")]
        public byte[] CreatedAt { get; set; }

        [ForeignKey("HiredLeaderId")]
        [InverseProperty("HiredUnits")]
        public virtual HiredLeader HiredLeader { get; set; }
        [ForeignKey("UnitId")]
        [InverseProperty("HiredUnits")]
        public virtual Unit Unit { get; set; }
        [ForeignKey("UnitLevel")]
        [InverseProperty("HiredUnits")]
        public virtual UnitLevel UnitLevelNavigation { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("HiredUnits")]
        public virtual User User { get; set; }
        [InverseProperty("HiredUnit")]
        public virtual ICollection<HiredUnitsStat> HiredUnitsStats { get; set; }
        [InverseProperty("HiredUnit")]
        public virtual ICollection<UnitGroup> UnitGroups { get; set; }
    }
}
