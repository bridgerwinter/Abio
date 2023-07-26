using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("BuildingsLevels", Schema = "Lookup")]
    public partial class BuildingsLevel
    {
        public BuildingsLevel()
        {
            ConstructedBuildings = new HashSet<ConstructedBuilding>();
        }

        [Key]
        public int BuildingLevelId { get; set; }
        [Unicode(false)]
        public string BuildingRankName { get; set; }

        [InverseProperty("BuildingLevelNavigation")]
        public virtual ICollection<ConstructedBuilding> ConstructedBuildings { get; set; }
    }
}
