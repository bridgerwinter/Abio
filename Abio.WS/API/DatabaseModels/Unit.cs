using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("Units", Schema = "Lookup")]
    public partial class Unit
    {
        public Unit()
        {
            HiredUnits = new HashSet<HiredUnit>();
        }

        [Key]
        public int UnitId { get; set; }
        [Unicode(false)]
        public string UnitName { get; set; }
        public int? FactionId { get; set; }
        public int? Health { get; set; }
        public int? Attack { get; set; }
        public int? Defense { get; set; }

        [ForeignKey("FactionId")]
        [InverseProperty("Units")]
        public virtual Faction Faction { get; set; }
        [InverseProperty("Unit")]
        public virtual ICollection<HiredUnit> HiredUnits { get; set; }
    }
}
