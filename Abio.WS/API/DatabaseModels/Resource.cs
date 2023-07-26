using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Abio.WS.API.DatabaseModels
{
    [Table("Resources", Schema = "Lookup")]
    public partial class Resource
    {
        public Resource()
        {
            ResourceInventories = new HashSet<ResourceInventory>();
        }

        [Key]
        public int ResourceId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string ResourceName { get; set; }

        [InverseProperty("Resource")]
        public virtual ICollection<ResourceInventory> ResourceInventories { get; set; }
    }
}
