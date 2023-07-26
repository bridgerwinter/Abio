using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("Players", Schema = "Player")]
    public partial class Player
    {
        [Key]
        public Guid? UserId { get; set; }
        public int? MaxCities { get; set; }
        public int? MaxOwnedLand { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
