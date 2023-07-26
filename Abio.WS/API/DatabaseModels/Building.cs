using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("Buildings", Schema = "Lookup")]
    public partial class Building
    {
        public Building()
        {
            ConstructedBuildings = new HashSet<ConstructedBuilding>();
        }

        [Key]
        public int BuildingId { get; set; }
        [Unicode(false)]
        public string BuildingName { get; set; }
        public int? FactionId { get; set; }

        [ForeignKey("FactionId")]
        [InverseProperty("Buildings")]
        public virtual Faction Faction { get; set; }
        [InverseProperty("Building")]
        public virtual ICollection<ConstructedBuilding> ConstructedBuildings { get; set; }
    }
}
