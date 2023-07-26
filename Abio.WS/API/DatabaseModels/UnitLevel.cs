using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("UnitLevels", Schema = "Lookup")]
    public partial class UnitLevel
    {
        public UnitLevel()
        {
            HiredUnits = new HashSet<HiredUnit>();
        }

        [Key]
        public int UnitLevelId { get; set; }
        [Unicode(false)]
        public string UnitRankName { get; set; }

        [InverseProperty("UnitLevelNavigation")]
        public virtual ICollection<HiredUnit> HiredUnits { get; set; }
    }
}
