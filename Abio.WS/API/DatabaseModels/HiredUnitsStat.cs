using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("HiredUnitsStats", Schema = "Player")]
    public partial class HiredUnitsStat
    {
        [Key]
        public Guid HiredUnitStatsId { get; set; }
        public Guid? HiredUnitId { get; set; }
        public int? Leadership { get; set; }
        public int? Attack { get; set; }
        public int? Defense { get; set; }
        public int? MovementSpeed { get; set; }
        public int? AttackSpeed { get; set; }
        public int? MeleeRange { get; set; }
        public int? RangedRange { get; set; }

        [ForeignKey("HiredUnitId")]
        [InverseProperty("HiredUnitsStats")]
        public virtual HiredUnit HiredUnit { get; set; }
    }
}
