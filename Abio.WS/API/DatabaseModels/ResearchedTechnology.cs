using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{

    [Table("ResearchedTechnology", Schema = "Player")]
    public partial class ResearchedTechnology
    {
        [Key]
        public Guid? ResearchedTechnologyId { get; set; }
        public int? TechnologyId { get; set; }
        [Required]
        [Column("created_at")]
        public byte[] CreatedAt { get; set; }

        [ForeignKey("TechnologyId")]
        public virtual Technology Technology { get; set; }
    }
}
