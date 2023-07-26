using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("ConstructedBuildings", Schema = "Player")]
    public partial class ConstructedBuilding
    {
        [Key]
        public Guid ConstructuredBuildingId { get; set; }
        public int? BuildingId { get; set; }
        public Guid? UserId { get; set; }
        public int? BuildingLevel { get; set; }
        [Required]
        [Column("created_at")]
        public byte[] CreatedAt { get; set; }

        [ForeignKey("BuildingId")]
        [InverseProperty("ConstructedBuildings")]
        public virtual Building Building { get; set; }
        [ForeignKey("BuildingLevel")]
        [InverseProperty("ConstructedBuildings")]
        public virtual BuildingsLevel BuildingLevelNavigation { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("ConstructedBuildings")]
        public virtual User User { get; set; }
    }
}
