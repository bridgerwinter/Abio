using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("ResourceInventory", Schema = "Player")]
    public partial class ResourceInventory
    {
        [Key]
        public Guid ResourceInventoryId { get; set; }
        public Guid? UserId { get; set; }
        public int? ResourceId { get; set; }
        public long? Quantity { get; set; }

        [ForeignKey("ResourceId")]
        [InverseProperty("ResourceInventories")]
        public virtual Resource Resource { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("ResourceInventories")]
        public virtual User User { get; set; }
    }
}
