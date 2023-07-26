using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("Factions", Schema = "Lookup")]
    public partial class Faction
    {
        public Faction()
        {
            Buildings = new HashSet<Building>();
            Units = new HashSet<Unit>();
        }

        [Key]
        public int FactionId { get; set; }
        [Unicode(false)]
        public string FactionName { get; set; }

        [InverseProperty("Faction")]
        public virtual ICollection<Building> Buildings { get; set; }
        [InverseProperty("Faction")]
        public virtual ICollection<Unit> Units { get; set; }
    }
}
